use std::process::ExitCode;
use std::sync::atomic::{AtomicBool, Ordering};
use std::sync::Arc;
use std::time::{Duration, Instant};

enum Fail {
    NoAdapter,
    Compile(String),
    Runtime(String),
    Failwith(String),
}

fn fail_message(source: &str, site: u32) -> String {
    let marker = format!("// spiral-failwith {site}: ");
    let escaped = source.lines().find_map(|line| line.strip_prefix(marker.as_str())).unwrap_or("failwith");
    let mut text = String::new();
    let mut chars = escaped.chars();
    while let Some(c) = chars.next() {
        if c != '\\' {
            text.push(c);
            continue;
        }
        match chars.next() {
            Some('n') => text.push('\n'),
            Some('r') => text.push('\r'),
            Some(other) => text.push(other),
            None => text.push('\\'),
        }
    }
    text
}

fn main() -> ExitCode {
    let mut args = std::env::args().skip(1);
    let Some(path) = args.next() else {
        eprintln!("wgsl error: usage: spiral-wgsl <file.wgsl>");
        return ExitCode::from(2);
    };
    if args.next().is_some() {
        eprintln!("wgsl error: usage: spiral-wgsl <file.wgsl>");
        return ExitCode::from(2);
    }
    let source = match std::fs::read_to_string(&path) {
        Ok(text) => text,
        Err(error) => {
            eprintln!("wgsl error: {error}");
            return ExitCode::from(2);
        }
    };
    let lanes = env_u32("SPIRAL_WGSL_LANES", 1).max(1);
    let chunk = env_u32("SPIRAL_WGSL_CHUNK", 1024).max(64);
    match pollster::block_on(execute(&source, lanes, chunk)) {
        Ok(results) => {
            if lanes > 1 {
                for (lane, value) in results.iter().enumerate() {
                    println!("lane {lane}: {value}");
                }
            }
            std::process::exit(results[0])
        }
        Err(Fail::NoAdapter) => {
            eprintln!("wgsl error: no WebGPU adapter");
            ExitCode::from(3)
        }
        Err(Fail::Compile(message)) => {
            eprintln!("wgsl error: {message}");
            ExitCode::from(2)
        }
        Err(Fail::Runtime(message)) => {
            eprintln!("wgsl error: {message}");
            ExitCode::from(1)
        }
        Err(Fail::Failwith(message)) => {
            eprintln!("{message}");
            ExitCode::from(1)
        }
    }
}

fn env_u32(name: &str, default: u32) -> u32 {
    std::env::var(name).ok().and_then(|text| text.parse::<u32>().ok()).unwrap_or(default)
}

/// SPIRAL_WGSL_PASS_SIZES: the lanes each pass needs, as comma-separated N or COUNT:N (e.g. "1060:288,1:32000").
/// Unset means every pass covers all lanes. A pass needing fewer lanes dispatches fewer workgroups.
fn pass_lane_counts(text: Option<String>, passes: u32, lanes: u32) -> Result<Vec<u32>, Fail> {
    let Some(text) = text else { return Ok(vec![lanes; passes as usize]) };
    let mut counts = Vec::new();
    for part in text.split(',').map(str::trim).filter(|part| !part.is_empty()) {
        let (repeat, size) = match part.split_once(':') {
            Some((repeat, size)) => (repeat.trim().parse::<u32>(), size.trim().parse::<u32>()),
            None => (Ok(1), part.parse::<u32>()),
        };
        match (repeat, size) {
            (Ok(repeat), Ok(size)) => counts.extend(std::iter::repeat(size.min(lanes)).take(repeat as usize)),
            _ => return Err(Fail::Runtime(format!("SPIRAL_WGSL_PASS_SIZES: '{part}' is not N or COUNT:N"))),
        }
    }
    if counts.len() != passes as usize {
        return Err(Fail::Runtime(format!("SPIRAL_WGSL_PASS_SIZES lists {} passes but SPIRAL_WGSL_PASSES is {passes}", counts.len())));
    }
    Ok(counts)
}

fn wait_for<T>(device: &wgpu::Device, lost: &AtomicBool, receiver: &std::sync::mpsc::Receiver<T>, limit: Duration, what: &str) -> Result<T, Fail> {
    let started = Instant::now();
    loop {
        device.poll(wgpu::PollType::Poll).map_err(|error| Fail::Runtime(format!("{error} while {what}")))?;
        if let Ok(value) = receiver.try_recv() {
            return Ok(value);
        }
        if lost.load(Ordering::SeqCst) {
            return Err(Fail::Runtime(format!("device lost while {what} (GPU timeout? lower SPIRAL_WGSL_CHUNK)")));
        }
        if started.elapsed() > limit {
            return Err(Fail::Runtime(format!("no completion after {} s while {what} (GPU timeout? lower SPIRAL_WGSL_CHUNK)", limit.as_secs())));
        }
        std::thread::sleep(Duration::from_millis(1));
    }
}

async fn execute(source: &str, lanes: u32, chunk: u32) -> Result<Vec<i32>, Fail> {
    let instance = wgpu::Instance::new(wgpu::InstanceDescriptor::new_without_display_handle_from_env());
    let adapter = match wgpu::util::initialize_adapter_from_env(&instance, None).await { Ok(adapter) => adapter, Err(_) => request_adapter(&instance).await.ok_or(Fail::NoAdapter)? };
    let timing = std::env::var_os("SPIRAL_WGSL_TIMING").is_some();
    let timing_log = std::env::var_os("SPIRAL_WGSL_TIMING_LOG");
    let info = adapter.get_info();
    let adapter_text = format!("{} backend {:?} type {:?} driver {} {}", info.name, info.backend, info.device_type, info.driver, info.driver_info);
    if timing {
        eprintln!("wgsl timing adapter {adapter_text}");
    }
    let compile_started = Instant::now();
    let (device, queue) = adapter
        .request_device(&wgpu::DeviceDescriptor { required_limits: adapter.limits(), ..Default::default() })
        .await
        .map_err(|error| Fail::Runtime(error.to_string()))?;
    let lost = Arc::new(AtomicBool::new(false));
    let lost_flag = lost.clone();
    device.set_device_lost_callback(move |_, _| lost_flag.store(true, Ordering::SeqCst));
    let limit = Duration::from_secs(env_u32("SPIRAL_WGSL_TIMEOUT_SECONDS", 120) as u64);

    let compile_scope = device.push_error_scope(wgpu::ErrorFilter::Validation);
    let marker = "// spiral-module ";
    let starts: Vec<usize> = source.match_indices(marker).map(|(at, _)| at).collect();
    let pieces: Vec<&str> = if starts.is_empty() {
        vec![source]
    } else {
        starts.iter().enumerate().map(|(k, &at)| &source[at..starts.get(k + 1).copied().unwrap_or(source.len())]).collect()
    };
    let stage_words: u64 = source
        .lines()
        .find_map(|line| line.strip_prefix(marker).and_then(|rest| rest.split("stage-words ").nth(1)).and_then(|w| w.trim().parse().ok()))
        .unwrap_or(if starts.is_empty() && source.contains("@binding(4)") { 1 } else { 0 });
    let shader_modules: Vec<wgpu::ShaderModule> = pieces
        .iter()
        .map(|piece| device.create_shader_module(wgpu::ShaderModuleDescriptor { label: Some("spiral.wgsl"), source: wgpu::ShaderSource::Wgsl((*piece).into()) }))
        .collect();
    let storage_entry = |binding| wgpu::BindGroupLayoutEntry {
        binding,
        visibility: wgpu::ShaderStages::COMPUTE,
        ty: wgpu::BindingType::Buffer {
            ty: wgpu::BufferBindingType::Storage { read_only: false },
            has_dynamic_offset: false,
            min_binding_size: None,
        },
        count: None,
    };
    let bind_layout = device.create_bind_group_layout(&wgpu::BindGroupLayoutDescriptor {
        label: Some("spiral-io"),
        entries: &[storage_entry(0), storage_entry(1), storage_entry(2), storage_entry(4), wgpu::BindGroupLayoutEntry { binding: 3, visibility: wgpu::ShaderStages::COMPUTE, ty: wgpu::BindingType::Buffer { ty: wgpu::BufferBindingType::Storage { read_only: true }, has_dynamic_offset: false, min_binding_size: None }, count: None }],
    });
    let pipeline_layout = device.create_pipeline_layout(&wgpu::PipelineLayoutDescriptor {
        label: Some("spiral"),
        bind_group_layouts: &[Some(&bind_layout)],
        immediate_size: 0,
    });
    let shape_header: Vec<u32> = if std::env::var("SPIRAL_WGSL_SHAPE_OVERRIDES").as_deref() == Ok("1") {
        let bytes = std::env::var_os("SPIRAL_WGSL_INPUT").map(|path| std::fs::read(path).expect("SPIRAL_WGSL_INPUT unreadable")).unwrap_or_default();
        (0..7).map(|i| bytes.get(i * 4..i * 4 + 4).map(|b| u32::from_le_bytes([b[0], b[1], b[2], b[3]])).unwrap_or(0)).collect()
    } else {
        Vec::new()
    };
    let shape_names = ["SHAPE_DIM", "SHAPE_HIDDEN", "SHAPE_LAYERS", "SHAPE_HEADS", "SHAPE_KV_HEADS", "SHAPE_VOCAB", "SHAPE_SEQ"];
    let module_constants: Vec<Vec<(&str, f64)>> = pieces
        .iter()
        .map(|piece| shape_header.iter().zip(shape_names).filter(|(_, name)| piece.contains(name)).map(|(value, name)| (name, *value as f64)).collect())
        .collect();
    let pipelines: Vec<wgpu::ComputePipeline> = shader_modules
        .iter()
        .zip(module_constants.iter())
        .map(|(module, constants)| {
            device.create_compute_pipeline(&wgpu::ComputePipelineDescriptor {
                label: Some("spiral"),
                layout: Some(&pipeline_layout),
                module,
                entry_point: Some("main"),
                compilation_options: wgpu::PipelineCompilationOptions { constants: constants, ..Default::default() },
                cache: None,
            })
        })
        .collect();
    if let Some(error) = compile_scope.pop().await {
        return Err(Fail::Compile(error.to_string()));
    }
    let compile_ms = compile_started.elapsed().as_millis();
    if timing {
        eprintln!("wgsl timing compile_ms {compile_ms}");
    }
    let run_started = Instant::now();

    let size = 256u64;
    let storage = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-io"),
        size,
        usage: wgpu::BufferUsages::STORAGE | wgpu::BufferUsages::COPY_SRC | wgpu::BufferUsages::COPY_DST,
        mapped_at_creation: false,
    });
    let readback = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-readback"),
        size,
        usage: wgpu::BufferUsages::MAP_READ | wgpu::BufferUsages::COPY_DST,
        mapped_at_creation: false,
    });
    let chunk_lanes = lanes.min(chunk);
    let heap_megabytes = env_u32("SPIRAL_WGSL_HEAP_MB", 64) as u64;
    let heap_bytes = (heap_megabytes * 1024 * 1024).min(device.limits().max_storage_buffer_binding_size).min(device.limits().max_buffer_size);
    let heap_words_per_lane = (heap_bytes / 4 / chunk_lanes as u64) as u32;
    queue.write_buffer(&storage, 0, &vec![0u8; size as usize]);
    let passes = env_u32("SPIRAL_WGSL_PASSES", 1).max(1);
    let pass_lanes = pass_lane_counts(std::env::var("SPIRAL_WGSL_PASS_SIZES").ok(), passes, lanes)?;
    let heap = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-heap"),
        size: heap_bytes,
        usage: if passes > 1 { wgpu::BufferUsages::STORAGE | wgpu::BufferUsages::COPY_DST } else { wgpu::BufferUsages::STORAGE },
        mapped_at_creation: false,
    });
    let pass_indices: Vec<u8> = (0..passes).flat_map(|p| p.to_le_bytes()).collect();
    let pass_buffer = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-passes"),
        size: (passes as u64 * 4).max(4),
        usage: wgpu::BufferUsages::COPY_SRC | wgpu::BufferUsages::COPY_DST,
        mapped_at_creation: false,
    });
    queue.write_buffer(&pass_buffer, 0, &pass_indices);
    let results_size = (lanes as u64 * 4).max(4);
    let results = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-results"),
        size: results_size,
        usage: wgpu::BufferUsages::STORAGE | wgpu::BufferUsages::COPY_SRC,
        mapped_at_creation: false,
    });
    let results_readback = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-results-readback"),
        size: results_size,
        usage: wgpu::BufferUsages::MAP_READ | wgpu::BufferUsages::COPY_DST,
        mapped_at_creation: false,
    });
    let mut input_bytes = std::env::var_os("SPIRAL_WGSL_INPUT").map(|path| std::fs::read(path).expect("SPIRAL_WGSL_INPUT unreadable")).unwrap_or_default();
    while input_bytes.len() < 4 || input_bytes.len() % 4 != 0 { input_bytes.push(0); }
    let input = device.create_buffer(&wgpu::BufferDescriptor { label: Some("spiral-input"), size: input_bytes.len() as u64, usage: wgpu::BufferUsages::STORAGE | wgpu::BufferUsages::COPY_DST, mapped_at_creation: false });
    queue.write_buffer(&input, 0, &input_bytes);
    let stage = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-stage"),
        size: (lanes as u64 * stage_words * 4).max(4),
        usage: wgpu::BufferUsages::STORAGE,
        mapped_at_creation: false,
    });
    let bind_group = device.create_bind_group(&wgpu::BindGroupDescriptor {
        label: Some("spiral-io"),
        layout: &bind_layout,
        entries: &[
            wgpu::BindGroupEntry { binding: 0, resource: storage.as_entire_binding() },
            wgpu::BindGroupEntry { binding: 1, resource: heap.as_entire_binding() },
            wgpu::BindGroupEntry { binding: 2, resource: results.as_entire_binding() },
            wgpu::BindGroupEntry { binding: 3, resource: input.as_entire_binding() },
            wgpu::BindGroupEntry { binding: 4, resource: stage.as_entire_binding() },
        ],
    });

    queue.submit(std::iter::empty::<wgpu::CommandBuffer>());
    let (sender, receiver) = std::sync::mpsc::channel();
    queue.on_submitted_work_done(move || {
        let _ = sender.send(());
    });
    wait_for(&device, &lost, &receiver, limit, "uploading the inputs")?;
    let forward_started = Instant::now();
    let mut lane_base = 0u32;
    while lane_base < lanes {
        let this_chunk = (lanes - lane_base).min(chunk_lanes);
        let mut header = [0u8; 12];
        header[0..4].copy_from_slice(&lanes.to_le_bytes());
        header[4..8].copy_from_slice(&heap_words_per_lane.to_le_bytes());
        header[8..12].copy_from_slice(&lane_base.to_le_bytes());
        queue.write_buffer(&storage, 4, &header);
        let mut encoder = device.create_command_encoder(&wgpu::CommandEncoderDescriptor::default());
        for p in 0..passes {
            let active = pass_lanes[p as usize].saturating_sub(lane_base).min(this_chunk);
            if active == 0 {
                continue;
            }
            if passes > 1 {
                encoder.copy_buffer_to_buffer(&pass_buffer, p as u64 * 4, &heap, 0, 4);
            }
            for pipeline in &pipelines {
                let mut pass = encoder.begin_compute_pass(&wgpu::ComputePassDescriptor::default());
                pass.set_pipeline(pipeline);
                pass.set_bind_group(0, &bind_group, &[]);
                pass.dispatch_workgroups(active.div_ceil(64), 1, 1);
            }
        }
        let submit_scope = device.push_error_scope(wgpu::ErrorFilter::Validation);
        queue.submit(Some(encoder.finish()));
        if let Some(error) = submit_scope.pop().await {
            return Err(Fail::Runtime(error.to_string()));
        }
        let (sender, receiver) = std::sync::mpsc::channel();
        queue.on_submitted_work_done(move || {
            let _ = sender.send(());
        });
        wait_for(&device, &lost, &receiver, limit, &format!("running lanes {lane_base}..{}", lane_base + this_chunk))?;
        lane_base += this_chunk;
    }
    let forward_us = forward_started.elapsed().as_micros();

    let mut encoder = device.create_command_encoder(&wgpu::CommandEncoderDescriptor::default());
    encoder.copy_buffer_to_buffer(&storage, 0, &readback, 0, size);
    encoder.copy_buffer_to_buffer(&results, 0, &results_readback, 0, results_size);
    queue.submit(Some(encoder.finish()));

    let slice = readback.slice(..);
    let (sender, receiver) = std::sync::mpsc::channel();
    slice.map_async(wgpu::MapMode::Read, move |result| {
        let _ = sender.send(result);
    });
    wait_for(&device, &lost, &receiver, limit, "reading the exit code")?.map_err(|error| Fail::Runtime(error.to_string()))?;
    let run_ms = run_started.elapsed().as_millis();
    if timing {
        eprintln!("wgsl timing run_ms {run_ms}");
        eprintln!("wgsl timing forward_us {forward_us}");
    }
    if let Some(log) = timing_log {
        use std::io::Write;
        let shader = std::env::var("SPIRAL_CELLS_TEST").ok().filter(|name| !name.is_empty()).unwrap_or_else(|| std::env::args().nth(1).unwrap_or_default());
        if let Ok(mut file) = std::fs::OpenOptions::new().create(true).append(true).open(log) {
            let _ = writeln!(file, "{shader}\t{}\t{compile_ms}\t{run_ms}\t{adapter_text}", source.len());
        }
    }
    let bytes = slice.get_mapped_range().map_err(|error| Fail::Runtime(error.to_string()))?;
    let code = i32::from_le_bytes(bytes[0..4].try_into().unwrap());
    let heap_overflow = u32::from_le_bytes(bytes[16..20].try_into().unwrap());
    let fail_site = u32::from_le_bytes(bytes[20..24].try_into().unwrap());
    drop(bytes);
    readback.unmap();
    if fail_site > 0 {
        return Err(Fail::Failwith(fail_message(source, fail_site)));
    }
    if heap_overflow > 0 {
        return Err(Fail::Runtime(format!("{heap_overflow} array allocations overflowed the lane heap of {heap_words_per_lane} words (raise SPIRAL_WGSL_HEAP_MB or lower SPIRAL_WGSL_CHUNK)")));
    }
    if lanes == 1 {
        return Ok(vec![code]);
    }
    let lane_slice = results_readback.slice(..);
    let (lane_sender, lane_receiver) = std::sync::mpsc::channel();
    lane_slice.map_async(wgpu::MapMode::Read, move |result| {
        let _ = lane_sender.send(result);
    });
    wait_for(&device, &lost, &lane_receiver, limit, "reading lane results")?.map_err(|error| Fail::Runtime(error.to_string()))?;
    let lane_bytes = lane_slice.get_mapped_range().map_err(|error| Fail::Runtime(error.to_string()))?;
    let values = lane_bytes
        .chunks_exact(4)
        .take(lanes as usize)
        .map(|chunk| i32::from_le_bytes(chunk.try_into().unwrap()))
        .collect();
    drop(lane_bytes);
    results_readback.unmap();
    Ok(values)
}

async fn request_adapter(instance: &wgpu::Instance) -> Option<wgpu::Adapter> {
    let mut options = wgpu::RequestAdapterOptions::default();
    if let Ok(adapter) = instance.request_adapter(&options).await {
        return Some(adapter);
    }
    options.force_fallback_adapter = true;
    instance.request_adapter(&options).await.ok()
}
