use std::process::ExitCode;
use std::sync::atomic::{AtomicBool, Ordering};
use std::sync::Arc;
use std::time::{Duration, Instant};

enum Fail {
    NoAdapter,
    Compile(String),
    Runtime(String),
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
    }
}

fn env_u32(name: &str, default: u32) -> u32 {
    std::env::var(name).ok().and_then(|text| text.parse::<u32>().ok()).unwrap_or(default)
}

fn wait_for<T>(device: &wgpu::Device, lost: &AtomicBool, receiver: &std::sync::mpsc::Receiver<T>, limit: Duration, what: &str) -> Result<T, Fail> {
    let started = Instant::now();
    loop {
        device.poll(wgpu::Maintain::Poll);
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
    let instance = wgpu::Instance::new(&wgpu::InstanceDescriptor::default());
    let adapter = request_adapter(&instance).await.ok_or(Fail::NoAdapter)?;
    let (device, queue) = adapter
        .request_device(&wgpu::DeviceDescriptor::default(), None)
        .await
        .map_err(|error| Fail::Runtime(error.to_string()))?;
    let lost = Arc::new(AtomicBool::new(false));
    let lost_flag = lost.clone();
    device.set_device_lost_callback(move |_, _| lost_flag.store(true, Ordering::SeqCst));
    let limit = Duration::from_secs(env_u32("SPIRAL_WGSL_TIMEOUT_SECONDS", 120) as u64);

    device.push_error_scope(wgpu::ErrorFilter::Validation);
    let module = device.create_shader_module(wgpu::ShaderModuleDescriptor {
        label: Some("spiral.wgsl"),
        source: wgpu::ShaderSource::Wgsl(source.into()),
    });
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
        entries: &[storage_entry(0), storage_entry(1), storage_entry(2)],
    });
    let pipeline_layout = device.create_pipeline_layout(&wgpu::PipelineLayoutDescriptor {
        label: Some("spiral"),
        bind_group_layouts: &[&bind_layout],
        push_constant_ranges: &[],
    });
    let pipeline = device.create_compute_pipeline(&wgpu::ComputePipelineDescriptor {
        label: Some("spiral"),
        layout: Some(&pipeline_layout),
        module: &module,
        entry_point: Some("main"),
        compilation_options: Default::default(),
        cache: None,
    });
    if let Some(error) = device.pop_error_scope().await {
        return Err(Fail::Compile(error.to_string()));
    }

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
    let heap_bytes = (heap_megabytes * 1024 * 1024).min(device.limits().max_storage_buffer_binding_size as u64);
    let heap_words_per_lane = (heap_bytes / 4 / chunk_lanes as u64) as u32;
    queue.write_buffer(&storage, 0, &vec![0u8; size as usize]);
    let heap = device.create_buffer(&wgpu::BufferDescriptor {
        label: Some("spiral-heap"),
        size: heap_bytes,
        usage: wgpu::BufferUsages::STORAGE,
        mapped_at_creation: false,
    });
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
    let bind_group = device.create_bind_group(&wgpu::BindGroupDescriptor {
        label: Some("spiral-io"),
        layout: &bind_layout,
        entries: &[
            wgpu::BindGroupEntry { binding: 0, resource: storage.as_entire_binding() },
            wgpu::BindGroupEntry { binding: 1, resource: heap.as_entire_binding() },
            wgpu::BindGroupEntry { binding: 2, resource: results.as_entire_binding() },
        ],
    });

    let mut lane_base = 0u32;
    while lane_base < lanes {
        let this_chunk = (lanes - lane_base).min(chunk_lanes);
        let mut header = [0u8; 12];
        header[0..4].copy_from_slice(&lanes.to_le_bytes());
        header[4..8].copy_from_slice(&heap_words_per_lane.to_le_bytes());
        header[8..12].copy_from_slice(&lane_base.to_le_bytes());
        queue.write_buffer(&storage, 4, &header);
        let mut encoder = device.create_command_encoder(&wgpu::CommandEncoderDescriptor::default());
        {
            let mut pass = encoder.begin_compute_pass(&wgpu::ComputePassDescriptor::default());
            pass.set_pipeline(&pipeline);
            pass.set_bind_group(0, &bind_group, &[]);
            pass.dispatch_workgroups(this_chunk.div_ceil(64), 1, 1);
        }
        device.push_error_scope(wgpu::ErrorFilter::Validation);
        queue.submit(Some(encoder.finish()));
        if let Some(error) = device.pop_error_scope().await {
            return Err(Fail::Runtime(error.to_string()));
        }
        let (sender, receiver) = std::sync::mpsc::channel();
        queue.on_submitted_work_done(move || {
            let _ = sender.send(());
        });
        wait_for(&device, &lost, &receiver, limit, &format!("running lanes {lane_base}..{}", lane_base + this_chunk))?;
        lane_base += this_chunk;
    }

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
    let bytes = slice.get_mapped_range();
    let code = i32::from_le_bytes(bytes[0..4].try_into().unwrap());
    drop(bytes);
    readback.unmap();
    if lanes == 1 {
        return Ok(vec![code]);
    }
    let lane_slice = results_readback.slice(..);
    let (lane_sender, lane_receiver) = std::sync::mpsc::channel();
    lane_slice.map_async(wgpu::MapMode::Read, move |result| {
        let _ = lane_sender.send(result);
    });
    wait_for(&device, &lost, &lane_receiver, limit, "reading lane results")?.map_err(|error| Fail::Runtime(error.to_string()))?;
    let lane_bytes = lane_slice.get_mapped_range();
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
    if let Some(adapter) = instance.request_adapter(&options).await {
        return Some(adapter);
    }
    options.force_fallback_adapter = true;
    instance.request_adapter(&options).await
}
