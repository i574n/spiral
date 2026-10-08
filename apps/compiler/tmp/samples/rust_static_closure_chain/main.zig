const std = @import("std");
const builtin = @import("builtin");
var spiral_arena = std.heap.ArenaAllocator.init(std.heap.page_allocator);
extern "kernel32" fn GetStdHandle(id: u32) callconv(.winapi) ?*anyopaque;
extern "kernel32" fn WriteFile(handle: ?*anyopaque, buffer: [*]const u8, length: u32, written: ?*u32, overlapped: ?*anyopaque) callconv(.winapi) i32;
fn spiralWrite(stream: u2, bytes: []const u8) void {
    if (builtin.os.tag == .windows) {
        const handle = GetStdHandle(if (stream == 1) 0xFFFFFFF5 else 0xFFFFFFF4);
        var rest = bytes;
        while (rest.len > 0) {
            var written: u32 = 0;
            const chunk: u32 = @intCast(@min(rest.len, 1 << 30));
            if (WriteFile(handle, rest.ptr, chunk, &written, null) == 0) return;
            rest = rest[written..];
        }
    } else if (builtin.os.tag == .linux) {
        var rest = bytes;
        while (rest.len > 0) {
            const n = std.os.linux.write(stream, rest.ptr, rest.len);
            if (@as(isize, @bitCast(n)) <= 0) return;
            rest = rest[n..];
        }
    } else {
        _ = std.c.write(stream, bytes.ptr, bytes.len);
    }
}
pub const panic = std.debug.FullPanic(spiralPanic);
fn spiralPanic(message: []const u8, _: ?usize) noreturn {
    spiralFlush();
    spiralWrite(2, message);
    spiralWrite(2, "\n");
    std.process.exit(3);
}
var spiral_gpa: std.mem.Allocator = undefined;
var spiral_true: bool = true;
var spiral_out_buffer: [1 << 16]u8 = undefined;
var spiral_out_len: usize = 0;
fn spiralFlush() void {
    if (spiral_out_len == 0) return;
    spiralWrite(1, spiral_out_buffer[0..spiral_out_len]);
    spiral_out_len = 0;
}
fn spiralPrint(s: []const u8) void {
    if (s.len > spiral_out_buffer.len - spiral_out_len) spiralFlush();
    if (s.len > spiral_out_buffer.len) {
        spiralWrite(1, s);
        return;
    }
    @memcpy(spiral_out_buffer[spiral_out_len..][0..s.len], s);
    spiral_out_len += s.len;
}
fn spiralPrintAny(x: anytype) void {
    const T = @TypeOf(x);
    if (T == []const u8) return spiralPrint(x);
    const s = switch (@typeInfo(T)) {
        .float => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
        .bool => std.fmt.allocPrint(spiral_gpa, "{}", .{x}),
        else => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
    } catch @panic("out of memory");
    spiralPrint(s);
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
}
fn spiralConv(comptime T: type, x: anytype) T {
    const S = @TypeOf(x);
    if (@typeInfo(T) == .float) {
        if (@typeInfo(S) == .float) return @floatCast(x) else return @floatFromInt(x);
    }
    if (@typeInfo(S) == .float) return @intFromFloat(x);
    const U = @Int(.unsigned, @bitSizeOf(T));
    const wide: i128 = x;
    return @bitCast(@as(U, @truncate(@as(u128, @bitCast(wide)))));
}
fn spiralConcat(a: []const u8, b: []const u8) []const u8 {
    return std.mem.concat(spiral_gpa, u8, &.{ a, b }) catch @panic("out of memory");
}
fn spiralStringSlice(s: []const u8, from: i64, upto: i64) []const u8 {
    const len: i64 = @intCast(s.len);
    if (from < 0 or from > len or upto < from - 1 or upto >= len) std.process.exit(3);
    if (upto < from) return "";
    const a: usize = @intCast(from);
    const b: usize = @intCast(upto + 1);
    if ((s[a] & 0xC0) == 0x80 or (b < s.len and (s[b] & 0xC0) == 0x80)) std.process.exit(3);
    return s[a..b];
}
fn spiralIndex(len: usize, i: anytype) usize {
    if (i < 0 or i >= len) std.process.exit(3);
    return @intCast(i);
}
fn spiralNewArray(comptime T: type, n: anytype) []T {
    const len: usize = @intCast(n);
    const a = spiral_gpa.alloc(T, len) catch @panic("out of memory");
    switch (@typeInfo(T)) {
        .int, .float, .bool => @memset(a, std.mem.zeroes(T)),
        else => if (T == []const u8) @memset(a, ""),
    }
    return a;
}
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const UH0 = struct { tag: i32, c0_0: u64 = undefined, c0_1: Fun0 = undefined };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque) *UH0 };
const ClosureEnv0 = struct { pad: u8 = 0 };
const ClosureEnv1 = struct { pad: u8 = 0 };
const ClosureEnv2 = struct { pad: u8 = 0 };
const ClosureEnv3 = struct { pad: u8 = 0 };
const ClosureEnv4 = struct { pad: u8 = 0 };
const ClosureEnv5 = struct { pad: u8 = 0 };
const ClosureEnv6 = struct { pad: u8 = 0 };
const ClosureEnv7 = struct { pad: u8 = 0 };
const ClosureEnv8 = struct { pad: u8 = 0 };
const ClosureEnv9 = struct { pad: u8 = 0 };
const ClosureEnv10 = struct { pad: u8 = 0 };
const ClosureEnv11 = struct { pad: u8 = 0 };
const ClosureEnv12 = struct { pad: u8 = 0 };
const ClosureEnv13 = struct { pad: u8 = 0 };
const ClosureEnv14 = struct { pad: u8 = 0 };
const ClosureEnv15 = struct { pad: u8 = 0 };
const ClosureEnv16 = struct { pad: u8 = 0 };
const ClosureEnv17 = struct { pad: u8 = 0 };
const ClosureEnv18 = struct { pad: u8 = 0 };
const ClosureEnv19 = struct { pad: u8 = 0 };
const ClosureEnv20 = struct { pad: u8 = 0 };
const ClosureEnv21 = struct { pad: u8 = 0 };
const ClosureEnv22 = struct { pad: u8 = 0 };
const ClosureEnv23 = struct { pad: u8 = 0 };
const ClosureEnv24 = struct { pad: u8 = 0 };
const ClosureEnv25 = struct { pad: u8 = 0 };
const ClosureEnv26 = struct { pad: u8 = 0 };
const ClosureEnv27 = struct { pad: u8 = 0 };
const ClosureEnv28 = struct { pad: u8 = 0 };
const ClosureEnv29 = struct { pad: u8 = 0 };
const ClosureEnv30 = struct { pad: u8 = 0 };
const ClosureEnv31 = struct { pad: u8 = 0 };
const ClosureEnv32 = struct { pad: u8 = 0 };
const ClosureEnv33 = struct { pad: u8 = 0 };
const ClosureEnv34 = struct { pad: u8 = 0 };
const ClosureEnv35 = struct { pad: u8 = 0 };
const ClosureEnv36 = struct { pad: u8 = 0 };
const ClosureEnv37 = struct { pad: u8 = 0 };
const ClosureEnv38 = struct { pad: u8 = 0 };
const ClosureEnv39 = struct { pad: u8 = 0 };
const ClosureEnv40 = struct { pad: u8 = 0 };
const ClosureEnv41 = struct { pad: u8 = 0 };
const ClosureEnv42 = struct { pad: u8 = 0 };
const ClosureEnv43 = struct { pad: u8 = 0 };
const ClosureEnv44 = struct { pad: u8 = 0 };
const ClosureEnv45 = struct { pad: u8 = 0 };
const ClosureEnv46 = struct { pad: u8 = 0 };
const ClosureEnv47 = struct { pad: u8 = 0 };
const ClosureEnv48 = struct { pad: u8 = 0 };
const ClosureEnv49 = struct { pad: u8 = 0 };
const ClosureEnv50 = struct { pad: u8 = 0 };
const ClosureEnv51 = struct { pad: u8 = 0 };
const ClosureEnv52 = struct { pad: u8 = 0 };
const ClosureEnv53 = struct { pad: u8 = 0 };
const ClosureEnv54 = struct { pad: u8 = 0 };
const ClosureEnv55 = struct { pad: u8 = 0 };
const ClosureEnv56 = struct { pad: u8 = 0 };
const ClosureEnv57 = struct { pad: u8 = 0 };
const ClosureEnv58 = struct { pad: u8 = 0 };
const ClosureEnv59 = struct { pad: u8 = 0 };
const ClosureEnv60 = struct { pad: u8 = 0 };
const ClosureEnv61 = struct { pad: u8 = 0 };
const ClosureEnv62 = struct { pad: u8 = 0 };
const ClosureEnv63 = struct { pad: u8 = 0 };
const ClosureEnv64 = struct { pad: u8 = 0 };
const ClosureEnv65 = struct { pad: u8 = 0 };
const ClosureEnv66 = struct { pad: u8 = 0 };
const ClosureEnv67 = struct { pad: u8 = 0 };
const ClosureEnv68 = struct { pad: u8 = 0 };
const ClosureEnv69 = struct { pad: u8 = 0 };
const ClosureEnv70 = struct { pad: u8 = 0 };
const ClosureEnv71 = struct { pad: u8 = 0 };
const ClosureEnv72 = struct { pad: u8 = 0 };
const ClosureEnv73 = struct { pad: u8 = 0 };
const ClosureEnv74 = struct { pad: u8 = 0 };
const ClosureEnv75 = struct { pad: u8 = 0 };
const ClosureEnv76 = struct { pad: u8 = 0 };
const ClosureEnv77 = struct { pad: u8 = 0 };
const ClosureEnv78 = struct { pad: u8 = 0 };
const ClosureEnv79 = struct { pad: u8 = 0 };
fn UH0_0(a0: u64, a1: Fun0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH0_1() *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1 });
}
fn closure79(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv79 = @ptrCast(@alignCast(ctx)); _ = &env;

    return UH0_1();
}
fn closureCreate79() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv79, .{ }), .call = &closure79 };
}
fn closure78(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv78 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate79();
    return UH0_0(@as(u64, 1), v0);
}
fn closureCreate78() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv78, .{ }), .call = &closure78 };
}
fn closure77(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv77 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate78();
    return UH0_0(@as(u64, 2), v0);
}
fn closureCreate77() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv77, .{ }), .call = &closure77 };
}
fn closure76(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv76 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate77();
    return UH0_0(@as(u64, 3), v0);
}
fn closureCreate76() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv76, .{ }), .call = &closure76 };
}
fn closure75(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv75 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate76();
    return UH0_0(@as(u64, 4), v0);
}
fn closureCreate75() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv75, .{ }), .call = &closure75 };
}
fn closure74(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv74 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate75();
    return UH0_0(@as(u64, 5), v0);
}
fn closureCreate74() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv74, .{ }), .call = &closure74 };
}
fn closure73(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv73 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate74();
    return UH0_0(@as(u64, 6), v0);
}
fn closureCreate73() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv73, .{ }), .call = &closure73 };
}
fn closure72(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv72 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate73();
    return UH0_0(@as(u64, 7), v0);
}
fn closureCreate72() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv72, .{ }), .call = &closure72 };
}
fn closure71(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv71 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate72();
    return UH0_0(@as(u64, 8), v0);
}
fn closureCreate71() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv71, .{ }), .call = &closure71 };
}
fn closure70(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv70 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate71();
    return UH0_0(@as(u64, 9), v0);
}
fn closureCreate70() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv70, .{ }), .call = &closure70 };
}
fn closure69(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv69 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate70();
    return UH0_0(@as(u64, 10), v0);
}
fn closureCreate69() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv69, .{ }), .call = &closure69 };
}
fn closure68(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv68 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate69();
    return UH0_0(@as(u64, 11), v0);
}
fn closureCreate68() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv68, .{ }), .call = &closure68 };
}
fn closure67(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv67 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate68();
    return UH0_0(@as(u64, 12), v0);
}
fn closureCreate67() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv67, .{ }), .call = &closure67 };
}
fn closure66(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv66 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate67();
    return UH0_0(@as(u64, 13), v0);
}
fn closureCreate66() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv66, .{ }), .call = &closure66 };
}
fn closure65(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv65 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate66();
    return UH0_0(@as(u64, 14), v0);
}
fn closureCreate65() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv65, .{ }), .call = &closure65 };
}
fn closure64(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv64 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate65();
    return UH0_0(@as(u64, 15), v0);
}
fn closureCreate64() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv64, .{ }), .call = &closure64 };
}
fn closure63(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv63 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate64();
    return UH0_0(@as(u64, 16), v0);
}
fn closureCreate63() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv63, .{ }), .call = &closure63 };
}
fn closure62(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv62 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate63();
    return UH0_0(@as(u64, 17), v0);
}
fn closureCreate62() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv62, .{ }), .call = &closure62 };
}
fn closure61(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv61 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate62();
    return UH0_0(@as(u64, 18), v0);
}
fn closureCreate61() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv61, .{ }), .call = &closure61 };
}
fn closure60(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv60 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate61();
    return UH0_0(@as(u64, 19), v0);
}
fn closureCreate60() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv60, .{ }), .call = &closure60 };
}
fn closure59(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv59 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate60();
    return UH0_0(@as(u64, 20), v0);
}
fn closureCreate59() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv59, .{ }), .call = &closure59 };
}
fn closure58(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv58 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate59();
    return UH0_0(@as(u64, 21), v0);
}
fn closureCreate58() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv58, .{ }), .call = &closure58 };
}
fn closure57(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv57 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate58();
    return UH0_0(@as(u64, 22), v0);
}
fn closureCreate57() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv57, .{ }), .call = &closure57 };
}
fn closure56(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv56 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate57();
    return UH0_0(@as(u64, 23), v0);
}
fn closureCreate56() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv56, .{ }), .call = &closure56 };
}
fn closure55(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv55 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate56();
    return UH0_0(@as(u64, 24), v0);
}
fn closureCreate55() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv55, .{ }), .call = &closure55 };
}
fn closure54(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv54 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate55();
    return UH0_0(@as(u64, 25), v0);
}
fn closureCreate54() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv54, .{ }), .call = &closure54 };
}
fn closure53(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv53 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate54();
    return UH0_0(@as(u64, 26), v0);
}
fn closureCreate53() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv53, .{ }), .call = &closure53 };
}
fn closure52(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv52 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate53();
    return UH0_0(@as(u64, 27), v0);
}
fn closureCreate52() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv52, .{ }), .call = &closure52 };
}
fn closure51(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv51 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate52();
    return UH0_0(@as(u64, 28), v0);
}
fn closureCreate51() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv51, .{ }), .call = &closure51 };
}
fn closure50(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv50 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate51();
    return UH0_0(@as(u64, 29), v0);
}
fn closureCreate50() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv50, .{ }), .call = &closure50 };
}
fn closure49(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv49 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate50();
    return UH0_0(@as(u64, 30), v0);
}
fn closureCreate49() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv49, .{ }), .call = &closure49 };
}
fn closure48(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv48 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate49();
    return UH0_0(@as(u64, 31), v0);
}
fn closureCreate48() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv48, .{ }), .call = &closure48 };
}
fn closure47(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv47 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate48();
    return UH0_0(@as(u64, 32), v0);
}
fn closureCreate47() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv47, .{ }), .call = &closure47 };
}
fn closure46(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv46 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate47();
    return UH0_0(@as(u64, 33), v0);
}
fn closureCreate46() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv46, .{ }), .call = &closure46 };
}
fn closure45(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv45 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate46();
    return UH0_0(@as(u64, 34), v0);
}
fn closureCreate45() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv45, .{ }), .call = &closure45 };
}
fn closure44(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv44 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate45();
    return UH0_0(@as(u64, 35), v0);
}
fn closureCreate44() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv44, .{ }), .call = &closure44 };
}
fn closure43(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv43 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate44();
    return UH0_0(@as(u64, 36), v0);
}
fn closureCreate43() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv43, .{ }), .call = &closure43 };
}
fn closure42(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv42 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate43();
    return UH0_0(@as(u64, 37), v0);
}
fn closureCreate42() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv42, .{ }), .call = &closure42 };
}
fn closure41(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv41 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate42();
    return UH0_0(@as(u64, 38), v0);
}
fn closureCreate41() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv41, .{ }), .call = &closure41 };
}
fn closure40(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv40 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate41();
    return UH0_0(@as(u64, 39), v0);
}
fn closureCreate40() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv40, .{ }), .call = &closure40 };
}
fn closure39(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv39 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate40();
    return UH0_0(@as(u64, 40), v0);
}
fn closureCreate39() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv39, .{ }), .call = &closure39 };
}
fn closure38(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv38 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate39();
    return UH0_0(@as(u64, 41), v0);
}
fn closureCreate38() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv38, .{ }), .call = &closure38 };
}
fn closure37(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv37 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate38();
    return UH0_0(@as(u64, 42), v0);
}
fn closureCreate37() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv37, .{ }), .call = &closure37 };
}
fn closure36(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv36 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate37();
    return UH0_0(@as(u64, 43), v0);
}
fn closureCreate36() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv36, .{ }), .call = &closure36 };
}
fn closure35(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv35 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate36();
    return UH0_0(@as(u64, 44), v0);
}
fn closureCreate35() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv35, .{ }), .call = &closure35 };
}
fn closure34(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv34 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate35();
    return UH0_0(@as(u64, 45), v0);
}
fn closureCreate34() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv34, .{ }), .call = &closure34 };
}
fn closure33(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv33 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate34();
    return UH0_0(@as(u64, 46), v0);
}
fn closureCreate33() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv33, .{ }), .call = &closure33 };
}
fn closure32(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv32 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate33();
    return UH0_0(@as(u64, 47), v0);
}
fn closureCreate32() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv32, .{ }), .call = &closure32 };
}
fn closure31(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv31 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate32();
    return UH0_0(@as(u64, 48), v0);
}
fn closureCreate31() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv31, .{ }), .call = &closure31 };
}
fn closure30(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv30 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate31();
    return UH0_0(@as(u64, 49), v0);
}
fn closureCreate30() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv30, .{ }), .call = &closure30 };
}
fn closure29(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv29 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate30();
    return UH0_0(@as(u64, 50), v0);
}
fn closureCreate29() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv29, .{ }), .call = &closure29 };
}
fn closure28(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv28 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate29();
    return UH0_0(@as(u64, 51), v0);
}
fn closureCreate28() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv28, .{ }), .call = &closure28 };
}
fn closure27(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv27 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate28();
    return UH0_0(@as(u64, 52), v0);
}
fn closureCreate27() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv27, .{ }), .call = &closure27 };
}
fn closure26(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv26 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate27();
    return UH0_0(@as(u64, 53), v0);
}
fn closureCreate26() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv26, .{ }), .call = &closure26 };
}
fn closure25(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv25 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate26();
    return UH0_0(@as(u64, 54), v0);
}
fn closureCreate25() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv25, .{ }), .call = &closure25 };
}
fn closure24(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv24 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate25();
    return UH0_0(@as(u64, 55), v0);
}
fn closureCreate24() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv24, .{ }), .call = &closure24 };
}
fn closure23(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv23 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate24();
    return UH0_0(@as(u64, 56), v0);
}
fn closureCreate23() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv23, .{ }), .call = &closure23 };
}
fn closure22(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv22 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate23();
    return UH0_0(@as(u64, 57), v0);
}
fn closureCreate22() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv22, .{ }), .call = &closure22 };
}
fn closure21(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv21 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate22();
    return UH0_0(@as(u64, 58), v0);
}
fn closureCreate21() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv21, .{ }), .call = &closure21 };
}
fn closure20(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv20 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate21();
    return UH0_0(@as(u64, 59), v0);
}
fn closureCreate20() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv20, .{ }), .call = &closure20 };
}
fn closure19(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv19 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate20();
    return UH0_0(@as(u64, 60), v0);
}
fn closureCreate19() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv19, .{ }), .call = &closure19 };
}
fn closure18(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv18 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate19();
    return UH0_0(@as(u64, 61), v0);
}
fn closureCreate18() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv18, .{ }), .call = &closure18 };
}
fn closure17(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv17 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate18();
    return UH0_0(@as(u64, 62), v0);
}
fn closureCreate17() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv17, .{ }), .call = &closure17 };
}
fn closure16(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv16 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate17();
    return UH0_0(@as(u64, 63), v0);
}
fn closureCreate16() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv16, .{ }), .call = &closure16 };
}
fn closure15(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv15 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate16();
    return UH0_0(@as(u64, 64), v0);
}
fn closureCreate15() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv15, .{ }), .call = &closure15 };
}
fn closure14(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv14 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate15();
    return UH0_0(@as(u64, 65), v0);
}
fn closureCreate14() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv14, .{ }), .call = &closure14 };
}
fn closure13(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv13 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate14();
    return UH0_0(@as(u64, 66), v0);
}
fn closureCreate13() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv13, .{ }), .call = &closure13 };
}
fn closure12(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv12 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate13();
    return UH0_0(@as(u64, 67), v0);
}
fn closureCreate12() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv12, .{ }), .call = &closure12 };
}
fn closure11(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv11 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate12();
    return UH0_0(@as(u64, 68), v0);
}
fn closureCreate11() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv11, .{ }), .call = &closure11 };
}
fn closure10(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv10 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate11();
    return UH0_0(@as(u64, 69), v0);
}
fn closureCreate10() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv10, .{ }), .call = &closure10 };
}
fn closure9(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv9 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate10();
    return UH0_0(@as(u64, 70), v0);
}
fn closureCreate9() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv9, .{ }), .call = &closure9 };
}
fn closure8(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv8 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate9();
    return UH0_0(@as(u64, 71), v0);
}
fn closureCreate8() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv8, .{ }), .call = &closure8 };
}
fn closure7(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv7 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate8();
    return UH0_0(@as(u64, 72), v0);
}
fn closureCreate7() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv7, .{ }), .call = &closure7 };
}
fn closure6(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv6 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate7();
    return UH0_0(@as(u64, 73), v0);
}
fn closureCreate6() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv6, .{ }), .call = &closure6 };
}
fn closure5(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv5 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate6();
    return UH0_0(@as(u64, 74), v0);
}
fn closureCreate5() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv5, .{ }), .call = &closure5 };
}
fn closure4(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv4 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate5();
    return UH0_0(@as(u64, 75), v0);
}
fn closureCreate4() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv4, .{ }), .call = &closure4 };
}
fn closure3(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv3 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate4();
    return UH0_0(@as(u64, 76), v0);
}
fn closureCreate3() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv3, .{ }), .call = &closure3 };
}
fn closure2(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv2 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate3();
    return UH0_0(@as(u64, 77), v0);
}
fn closureCreate2() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv2, .{ }), .call = &closure2 };
}
fn closure1(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv1 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate2();
    return UH0_0(@as(u64, 78), v0);
}
fn closureCreate1() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv1, .{ }), .call = &closure1 };
}
fn closure0(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: Fun0 = undefined; _ = &v0;
    v0 = closureCreate1();
    return UH0_0(@as(u64, 79), v0);
}
fn closureCreate0() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ }), .call = &closure0 };
}
fn loop_0(p0: *UH0, p1: u64) u64 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: u64 = p1; _ = &v1;
    var v2: u64 = undefined; _ = &v2;
    var v3: Fun0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: u64 = undefined; _ = &v5;
    var tmp4: *UH0 = undefined; _ = &tmp4;
    var tmp5: u64 = undefined; _ = &tmp5;
    while (true) {
        switch (v0.tag) {
            0 => {
                v2 = v0.c0_0;
                v3 = v0.c0_1;
                v4 = v3.call(v3.ctx);
                v5 = v1 +% v2;
                tmp4 = v4;
                tmp5 = v5;
                v0 = tmp4;
                v1 = tmp5;
                continue;
            },
            1 => {
                return v1;
            },
            else => unreachable,
        }
    }
}
fn spiralMain() i32 {
    var v0: u64 = undefined; _ = &v0;
    var v1: Fun0 = undefined; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: u64 = undefined; _ = &v3;
    var v4: u64 = undefined; _ = &v4;
    var v5: u64 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    v0 = @as(u64, 80);
    v1 = closureCreate0();
    v2 = UH0_0(v0, v1);
    v3 = @as(u64, 0);
    v4 = loop_0(v2, v3);
    v5 = @rem(v4, @as(u64, 200));
    v6 = spiralConv(i32, v5);
    return v6;
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
