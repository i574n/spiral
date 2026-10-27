fn spiral_abi_libm_cabs_pack(real_value: i32, imaginary_value: i32) i32 {
    const re: f64 = @floatFromInt(real_value);
    const im: f64 = @floatFromInt(imaginary_value);
    const magnitude = @sqrt(re * re + im * im);
    if (!(magnitude >= 0.0) or magnitude > 2147483647.0) @trap();
    const result: i32 = @intFromFloat(magnitude);
    if (@as(f64, @floatFromInt(result)) != magnitude) @trap();
    return result;
}
