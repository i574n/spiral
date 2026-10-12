use std::process::ExitCode;

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
    match pollster::block_on(execute(&source)) {
        Ok(code) => std::process::exit(code),
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

async fn execute(source: &str) -> Result<i32, Fail> {
    let instance = wgpu::Instance::new(&wgpu::InstanceDescriptor::default());
    let adapter = request_adapter(&instance).await.ok_or(Fail::NoAdapter)?;
    let (device, queue) = adapter
        .request_device(&wgpu::DeviceDescriptor::default(), None)
        .await
        .map_err(|error| Fail::Runtime(error.to_string()))?;

    device.push_error_scope(wgpu::ErrorFilter::Validation);
    let module = device.create_shader_module(wgpu::ShaderModuleDescriptor {
        label: Some("spiral.wgsl"),
        source: wgpu::ShaderSource::Wgsl(source.into()),
    });
    let bind_layout = device.create_bind_group_layout(&wgpu::BindGroupLayoutDescriptor {
        label: Some("spiral-io"),
        entries: &[wgpu::BindGroupLayoutEntry {
            binding: 0,
            visibility: wgpu::ShaderStages::COMPUTE,
            ty: wgpu::BindingType::Buffer {
                ty: wgpu::BufferBindingType::Storage { read_only: false },
                has_dynamic_offset: false,
                min_binding_size: None,
            },
            count: None,
        }],
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
    queue.write_buffer(&storage, 0, &vec![0u8; size as usize]);
    let bind_group = device.create_bind_group(&wgpu::BindGroupDescriptor {
        label: Some("spiral-io"),
        layout: &bind_layout,
        entries: &[wgpu::BindGroupEntry {
            binding: 0,
            resource: storage.as_entire_binding(),
        }],
    });

    let mut encoder = device.create_command_encoder(&wgpu::CommandEncoderDescriptor::default());
    {
        let mut pass = encoder.begin_compute_pass(&wgpu::ComputePassDescriptor::default());
        pass.set_pipeline(&pipeline);
        pass.set_bind_group(0, &bind_group, &[]);
        pass.dispatch_workgroups(1, 1, 1);
    }
    encoder.copy_buffer_to_buffer(&storage, 0, &readback, 0, size);
    device.push_error_scope(wgpu::ErrorFilter::Validation);
    queue.submit(Some(encoder.finish()));
    if let Some(error) = device.pop_error_scope().await {
        return Err(Fail::Runtime(error.to_string()));
    }

    let slice = readback.slice(..);
    let (sender, receiver) = std::sync::mpsc::channel();
    slice.map_async(wgpu::MapMode::Read, move |result| {
        let _ = sender.send(result);
    });
    device.poll(wgpu::Maintain::Wait);
    receiver
        .recv()
        .map_err(|error| Fail::Runtime(error.to_string()))?
        .map_err(|error| Fail::Runtime(error.to_string()))?;
    let bytes = slice.get_mapped_range();
    let code = i32::from_le_bytes(bytes[0..4].try_into().unwrap());
    drop(bytes);
    readback.unmap();
    Ok(code)
}

async fn request_adapter(instance: &wgpu::Instance) -> Option<wgpu::Adapter> {
    let mut options = wgpu::RequestAdapterOptions::default();
    if let Some(adapter) = instance.request_adapter(&options).await {
        return Some(adapter);
    }
    options.force_fallback_adapter = true;
    instance.request_adapter(&options).await
}
