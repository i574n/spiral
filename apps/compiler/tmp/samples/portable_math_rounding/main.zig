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
    var v23: bool = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v37: f64 = undefined; _ = &v37;
    var v42: bool = undefined; _ = &v42;
    var v43: bool = undefined; _ = &v43;
    var v119: f64 = undefined; _ = &v119;
    var v120: f64 = undefined; _ = &v120;
    var v121: bool = undefined; _ = &v121;
    var v131: f64 = undefined; _ = &v131;
    var v122: f64 = undefined; _ = &v122;
    var v123: bool = undefined; _ = &v123;
    var v124: f64 = undefined; _ = &v124;
    var v125: f64 = undefined; _ = &v125;
    var v126: f64 = undefined; _ = &v126;
    var v127: bool = undefined; _ = &v127;
    var v128: f64 = undefined; _ = &v128;
    var v172: bool = undefined; _ = &v172;
    var v173: bool = undefined; _ = &v173;
    var v174: f64 = undefined; _ = &v174;
    var v175: f64 = undefined; _ = &v175;
    var v176: bool = undefined; _ = &v176;
    var v186: f64 = undefined; _ = &v186;
    var v177: f64 = undefined; _ = &v177;
    var v178: bool = undefined; _ = &v178;
    var v179: f64 = undefined; _ = &v179;
    var v180: f64 = undefined; _ = &v180;
    var v181: f64 = undefined; _ = &v181;
    var v182: bool = undefined; _ = &v182;
    var v183: f64 = undefined; _ = &v183;
    var v187: bool = undefined; _ = &v187;
    var v188: bool = undefined; _ = &v188;
    var v189: f64 = undefined; _ = &v189;
    var v190: f64 = undefined; _ = &v190;
    var v191: bool = undefined; _ = &v191;
    var v201: f64 = undefined; _ = &v201;
    var v192: f64 = undefined; _ = &v192;
    var v193: bool = undefined; _ = &v193;
    var v194: f64 = undefined; _ = &v194;
    var v195: f64 = undefined; _ = &v195;
    var v196: f64 = undefined; _ = &v196;
    var v197: bool = undefined; _ = &v197;
    var v198: f64 = undefined; _ = &v198;
    var v202: bool = undefined; _ = &v202;
    var v203: bool = undefined; _ = &v203;
    var v204: f64 = undefined; _ = &v204;
    var v205: f64 = undefined; _ = &v205;
    var v206: bool = undefined; _ = &v206;
    var v216: f64 = undefined; _ = &v216;
    var v207: f64 = undefined; _ = &v207;
    var v208: bool = undefined; _ = &v208;
    var v209: f64 = undefined; _ = &v209;
    var v210: f64 = undefined; _ = &v210;
    var v211: f64 = undefined; _ = &v211;
    var v212: bool = undefined; _ = &v212;
    var v213: f64 = undefined; _ = &v213;
    var v217: bool = undefined; _ = &v217;
    var v218: bool = undefined; _ = &v218;
    var v219: f64 = undefined; _ = &v219;
    var v220: f64 = undefined; _ = &v220;
    var v221: bool = undefined; _ = &v221;
    var v231: f64 = undefined; _ = &v231;
    var v222: f64 = undefined; _ = &v222;
    var v223: bool = undefined; _ = &v223;
    var v224: f64 = undefined; _ = &v224;
    var v225: f64 = undefined; _ = &v225;
    var v226: f64 = undefined; _ = &v226;
    var v227: bool = undefined; _ = &v227;
    var v228: f64 = undefined; _ = &v228;
    var v232: bool = undefined; _ = &v232;
    var v233: bool = undefined; _ = &v233;
    var v242: f64 = undefined; _ = &v242;
    var v247: f64 = undefined; _ = &v247;
    var v248: f64 = undefined; _ = &v248;
    var v249: bool = undefined; _ = &v249;
    var v250: bool = undefined; _ = &v250;
    var v262: f32 = undefined; _ = &v262;
    var v267: bool = undefined; _ = &v267;
    var v268: bool = undefined; _ = &v268;
    v0 = @as(f64, 2.7);
    v1 = @as(f64, 3.2);
    v2 = @as(f64, -2.5);
    v3 = @as(f64, 3.5);
    v4 = @as(f64, 0.5);
    v5 = @as(f64, 1.0);
    v6 = @as(f32, 2.7);
    v18 = @floor(v0);
    v23 = v18 == @as(f64, 2.0);
    v24 = v23 != true;
    if (v24) {
        return @as(i32, 1);
    } else {
        v37 = @ceil(v0);
        v42 = v37 == @as(f64, 3.0);
        v43 = v42 != true;
        if (v43) {
            return @as(i32, 2);
        } else {
            v119 = @floor(v0);
            v120 = v0 - v119;
            v121 = v120 > @as(f64, 0.5);
            if (v121) {
                v122 = v119 + @as(f64, 1.0);
                v131 = v122;
            } else {
                v123 = v120 < @as(f64, 0.5);
                if (v123) {
                    v131 = v119;
                } else {
                    v124 = v119 / @as(f64, 2.0);
                    v125 = @floor(v124);
                    v126 = v125 * @as(f64, 2.0);
                    v127 = v126 == v119;
                    if (v127) {
                        v131 = v119;
                    } else {
                        v128 = v119 + @as(f64, 1.0);
                        v131 = v128;
                    }
                }
            }
            v172 = v131 == @as(f64, 3.0);
            v173 = v172 != true;
            if (v173) {
                return @as(i32, 3);
            } else {
                v174 = @floor(v1);
                v175 = v1 - v174;
                v176 = v175 > @as(f64, 0.5);
                if (v176) {
                    v177 = v174 + @as(f64, 1.0);
                    v186 = v177;
                } else {
                    v178 = v175 < @as(f64, 0.5);
                    if (v178) {
                        v186 = v174;
                    } else {
                        v179 = v174 / @as(f64, 2.0);
                        v180 = @floor(v179);
                        v181 = v180 * @as(f64, 2.0);
                        v182 = v181 == v174;
                        if (v182) {
                            v186 = v174;
                        } else {
                            v183 = v174 + @as(f64, 1.0);
                            v186 = v183;
                        }
                    }
                }
                v187 = v186 == @as(f64, 3.0);
                v188 = v187 != true;
                if (v188) {
                    return @as(i32, 4);
                } else {
                    v189 = @floor(v2);
                    v190 = v2 - v189;
                    v191 = v190 > @as(f64, 0.5);
                    if (v191) {
                        v192 = v189 + @as(f64, 1.0);
                        v201 = v192;
                    } else {
                        v193 = v190 < @as(f64, 0.5);
                        if (v193) {
                            v201 = v189;
                        } else {
                            v194 = v189 / @as(f64, 2.0);
                            v195 = @floor(v194);
                            v196 = v195 * @as(f64, 2.0);
                            v197 = v196 == v189;
                            if (v197) {
                                v201 = v189;
                            } else {
                                v198 = v189 + @as(f64, 1.0);
                                v201 = v198;
                            }
                        }
                    }
                    v202 = v201 == @as(f64, -2.0);
                    v203 = v202 != true;
                    if (v203) {
                        return @as(i32, 5);
                    } else {
                        v204 = @floor(v3);
                        v205 = v3 - v204;
                        v206 = v205 > @as(f64, 0.5);
                        if (v206) {
                            v207 = v204 + @as(f64, 1.0);
                            v216 = v207;
                        } else {
                            v208 = v205 < @as(f64, 0.5);
                            if (v208) {
                                v216 = v204;
                            } else {
                                v209 = v204 / @as(f64, 2.0);
                                v210 = @floor(v209);
                                v211 = v210 * @as(f64, 2.0);
                                v212 = v211 == v204;
                                if (v212) {
                                    v216 = v204;
                                } else {
                                    v213 = v204 + @as(f64, 1.0);
                                    v216 = v213;
                                }
                            }
                        }
                        v217 = v216 == @as(f64, 4.0);
                        v218 = v217 != true;
                        if (v218) {
                            return @as(i32, 6);
                        } else {
                            v219 = @floor(v4);
                            v220 = v4 - v219;
                            v221 = v220 > @as(f64, 0.5);
                            if (v221) {
                                v222 = v219 + @as(f64, 1.0);
                                v231 = v222;
                            } else {
                                v223 = v220 < @as(f64, 0.5);
                                if (v223) {
                                    v231 = v219;
                                } else {
                                    v224 = v219 / @as(f64, 2.0);
                                    v225 = @floor(v224);
                                    v226 = v225 * @as(f64, 2.0);
                                    v227 = v226 == v219;
                                    if (v227) {
                                        v231 = v219;
                                    } else {
                                        v228 = v219 + @as(f64, 1.0);
                                        v231 = v228;
                                    }
                                }
                            }
                            v232 = v231 == @as(f64, 0.0);
                            v233 = v232 != true;
                            if (v233) {
                                return @as(i32, 7);
                            } else {
                                v242 = std.math.atan2(v5, v5);
                                v247 = v242 * @as(f64, 1000.0);
                                v248 = @floor(v247);
                                v249 = v248 == @as(f64, 785.0);
                                v250 = v249 != true;
                                if (v250) {
                                    return @as(i32, 8);
                                } else {
                                    v262 = @floor(v6);
                                    v267 = v262 == @as(f32, 2.0);
                                    v268 = v267 != true;
                                    if (v268) {
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
