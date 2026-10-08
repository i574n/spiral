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
fn spiralMain() i32 {
    var v0: f64 = undefined; _ = &v0;
    var v1: f64 = undefined; _ = &v1;
    var v2: f64 = undefined; _ = &v2;
    var v3: f64 = undefined; _ = &v3;
    var v4: f64 = undefined; _ = &v4;
    var v5: f64 = undefined; _ = &v5;
    var v6: f32 = undefined; _ = &v6;
    var v18: f64 = undefined; _ = &v18;
    var v22: bool = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var v36: f64 = undefined; _ = &v36;
    var v40: bool = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var v117: f64 = undefined; _ = &v117;
    var v118: f64 = undefined; _ = &v118;
    var v119: bool = undefined; _ = &v119;
    var v129: f64 = undefined; _ = &v129;
    var v120: f64 = undefined; _ = &v120;
    var v121: bool = undefined; _ = &v121;
    var v122: f64 = undefined; _ = &v122;
    var v123: f64 = undefined; _ = &v123;
    var v124: f64 = undefined; _ = &v124;
    var v125: bool = undefined; _ = &v125;
    var v126: f64 = undefined; _ = &v126;
    var v169: bool = undefined; _ = &v169;
    var v170: bool = undefined; _ = &v170;
    var v171: f64 = undefined; _ = &v171;
    var v172: f64 = undefined; _ = &v172;
    var v173: bool = undefined; _ = &v173;
    var v183: f64 = undefined; _ = &v183;
    var v174: f64 = undefined; _ = &v174;
    var v175: bool = undefined; _ = &v175;
    var v176: f64 = undefined; _ = &v176;
    var v177: f64 = undefined; _ = &v177;
    var v178: f64 = undefined; _ = &v178;
    var v179: bool = undefined; _ = &v179;
    var v180: f64 = undefined; _ = &v180;
    var v184: bool = undefined; _ = &v184;
    var v185: bool = undefined; _ = &v185;
    var v186: f64 = undefined; _ = &v186;
    var v187: f64 = undefined; _ = &v187;
    var v188: bool = undefined; _ = &v188;
    var v198: f64 = undefined; _ = &v198;
    var v189: f64 = undefined; _ = &v189;
    var v190: bool = undefined; _ = &v190;
    var v191: f64 = undefined; _ = &v191;
    var v192: f64 = undefined; _ = &v192;
    var v193: f64 = undefined; _ = &v193;
    var v194: bool = undefined; _ = &v194;
    var v195: f64 = undefined; _ = &v195;
    var v199: bool = undefined; _ = &v199;
    var v200: bool = undefined; _ = &v200;
    var v201: f64 = undefined; _ = &v201;
    var v202: f64 = undefined; _ = &v202;
    var v203: bool = undefined; _ = &v203;
    var v213: f64 = undefined; _ = &v213;
    var v204: f64 = undefined; _ = &v204;
    var v205: bool = undefined; _ = &v205;
    var v206: f64 = undefined; _ = &v206;
    var v207: f64 = undefined; _ = &v207;
    var v208: f64 = undefined; _ = &v208;
    var v209: bool = undefined; _ = &v209;
    var v210: f64 = undefined; _ = &v210;
    var v214: bool = undefined; _ = &v214;
    var v215: bool = undefined; _ = &v215;
    var v216: f64 = undefined; _ = &v216;
    var v217: f64 = undefined; _ = &v217;
    var v218: bool = undefined; _ = &v218;
    var v228: f64 = undefined; _ = &v228;
    var v219: f64 = undefined; _ = &v219;
    var v220: bool = undefined; _ = &v220;
    var v221: f64 = undefined; _ = &v221;
    var v222: f64 = undefined; _ = &v222;
    var v223: f64 = undefined; _ = &v223;
    var v224: bool = undefined; _ = &v224;
    var v225: f64 = undefined; _ = &v225;
    var v229: bool = undefined; _ = &v229;
    var v230: bool = undefined; _ = &v230;
    var v239: f64 = undefined; _ = &v239;
    var v243: f64 = undefined; _ = &v243;
    var v244: f64 = undefined; _ = &v244;
    var v245: bool = undefined; _ = &v245;
    var v246: bool = undefined; _ = &v246;
    var v258: f32 = undefined; _ = &v258;
    var v262: bool = undefined; _ = &v262;
    var v263: bool = undefined; _ = &v263;
    v0 = @as(f64, 2.7);
    v1 = @as(f64, 3.2);
    v2 = @as(f64, -2.5);
    v3 = @as(f64, 3.5);
    v4 = @as(f64, 0.5);
    v5 = @as(f64, 1.0);
    v6 = @as(f32, 2.7);
    v18 = @floor(v0);
    v22 = v18 == @as(f64, 2.0);
    v23 = v22 != true;
    if (v23) {
        return @as(i32, 1);
    } else {
        v36 = @ceil(v0);
        v40 = v36 == @as(f64, 3.0);
        v41 = v40 != true;
        if (v41) {
            return @as(i32, 2);
        } else {
            v117 = @floor(v0);
            v118 = v0 - v117;
            v119 = v118 > @as(f64, 0.5);
            if (v119) {
                v120 = v117 + @as(f64, 1.0);
                v129 = v120;
            } else {
                v121 = v118 < @as(f64, 0.5);
                if (v121) {
                    v129 = v117;
                } else {
                    v122 = v117 / @as(f64, 2.0);
                    v123 = @floor(v122);
                    v124 = v123 * @as(f64, 2.0);
                    v125 = v124 == v117;
                    if (v125) {
                        v129 = v117;
                    } else {
                        v126 = v117 + @as(f64, 1.0);
                        v129 = v126;
                    }
                }
            }
            v169 = v129 == @as(f64, 3.0);
            v170 = v169 != true;
            if (v170) {
                return @as(i32, 3);
            } else {
                v171 = @floor(v1);
                v172 = v1 - v171;
                v173 = v172 > @as(f64, 0.5);
                if (v173) {
                    v174 = v171 + @as(f64, 1.0);
                    v183 = v174;
                } else {
                    v175 = v172 < @as(f64, 0.5);
                    if (v175) {
                        v183 = v171;
                    } else {
                        v176 = v171 / @as(f64, 2.0);
                        v177 = @floor(v176);
                        v178 = v177 * @as(f64, 2.0);
                        v179 = v178 == v171;
                        if (v179) {
                            v183 = v171;
                        } else {
                            v180 = v171 + @as(f64, 1.0);
                            v183 = v180;
                        }
                    }
                }
                v184 = v183 == @as(f64, 3.0);
                v185 = v184 != true;
                if (v185) {
                    return @as(i32, 4);
                } else {
                    v186 = @floor(v2);
                    v187 = v2 - v186;
                    v188 = v187 > @as(f64, 0.5);
                    if (v188) {
                        v189 = v186 + @as(f64, 1.0);
                        v198 = v189;
                    } else {
                        v190 = v187 < @as(f64, 0.5);
                        if (v190) {
                            v198 = v186;
                        } else {
                            v191 = v186 / @as(f64, 2.0);
                            v192 = @floor(v191);
                            v193 = v192 * @as(f64, 2.0);
                            v194 = v193 == v186;
                            if (v194) {
                                v198 = v186;
                            } else {
                                v195 = v186 + @as(f64, 1.0);
                                v198 = v195;
                            }
                        }
                    }
                    v199 = v198 == @as(f64, -2.0);
                    v200 = v199 != true;
                    if (v200) {
                        return @as(i32, 5);
                    } else {
                        v201 = @floor(v3);
                        v202 = v3 - v201;
                        v203 = v202 > @as(f64, 0.5);
                        if (v203) {
                            v204 = v201 + @as(f64, 1.0);
                            v213 = v204;
                        } else {
                            v205 = v202 < @as(f64, 0.5);
                            if (v205) {
                                v213 = v201;
                            } else {
                                v206 = v201 / @as(f64, 2.0);
                                v207 = @floor(v206);
                                v208 = v207 * @as(f64, 2.0);
                                v209 = v208 == v201;
                                if (v209) {
                                    v213 = v201;
                                } else {
                                    v210 = v201 + @as(f64, 1.0);
                                    v213 = v210;
                                }
                            }
                        }
                        v214 = v213 == @as(f64, 4.0);
                        v215 = v214 != true;
                        if (v215) {
                            return @as(i32, 6);
                        } else {
                            v216 = @floor(v4);
                            v217 = v4 - v216;
                            v218 = v217 > @as(f64, 0.5);
                            if (v218) {
                                v219 = v216 + @as(f64, 1.0);
                                v228 = v219;
                            } else {
                                v220 = v217 < @as(f64, 0.5);
                                if (v220) {
                                    v228 = v216;
                                } else {
                                    v221 = v216 / @as(f64, 2.0);
                                    v222 = @floor(v221);
                                    v223 = v222 * @as(f64, 2.0);
                                    v224 = v223 == v216;
                                    if (v224) {
                                        v228 = v216;
                                    } else {
                                        v225 = v216 + @as(f64, 1.0);
                                        v228 = v225;
                                    }
                                }
                            }
                            v229 = v228 == @as(f64, 0.0);
                            v230 = v229 != true;
                            if (v230) {
                                return @as(i32, 7);
                            } else {
                                v239 = std.math.atan2(v5, v5);
                                v243 = v239 * @as(f64, 1000.0);
                                v244 = @floor(v243);
                                v245 = v244 == @as(f64, 785.0);
                                v246 = v245 != true;
                                if (v246) {
                                    return @as(i32, 8);
                                } else {
                                    v258 = @floor(v6);
                                    v262 = v258 == @as(f32, 2.0);
                                    v263 = v262 != true;
                                    if (v263) {
                                        return @as(i32, 9);
                                    } else {
                                        return @as(i32, 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
