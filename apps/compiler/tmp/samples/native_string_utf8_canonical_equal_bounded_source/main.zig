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
var spiral_environ: std.process.Environ = .empty;
var spiral_true: bool = true;
var spiral_out_buffer: [1 << 16]u8 = undefined;
var spiral_out_len: usize = 0;
fn spiralFlush() void {
    if (spiral_out_len == 0) return;
    spiralWrite(1, spiral_out_buffer[0..spiral_out_len]);
    spiral_out_len = 0;
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
}
fn spiralIndex(len: usize, i: anytype) usize {
    if (i < 0 or i >= len) std.process.exit(3);
    return @intCast(i);
}
fn runtime_byte_2(p0: []const u8, p1: i32) u8 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    const v2: u8 = v0[spiralIndex(v0.len, v1)];
    return v2;
}
fn utf8_scalar_at_byte_offset_1(p0: []const u8, p1: i32) i32 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v5: bool = undefined; _ = &v5;
    var v7: u8 = undefined; _ = &v7;
    var v8: i32 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: u8 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v20: bool = undefined; _ = &v20;
    var v19: bool = undefined; _ = &v19;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v23: i32 = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v28: bool = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v32: i32 = undefined; _ = &v32;
    var v33: u8 = undefined; _ = &v33;
    var v34: i32 = undefined; _ = &v34;
    var v35: u8 = undefined; _ = &v35;
    var v36: i32 = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v39: bool = undefined; _ = &v39;
    var v38: bool = undefined; _ = &v38;
    var v40: bool = undefined; _ = &v40;
    var v42: bool = undefined; _ = &v42;
    var v41: bool = undefined; _ = &v41;
    var v43: i32 = undefined; _ = &v43;
    var v44: i32 = undefined; _ = &v44;
    var v45: i32 = undefined; _ = &v45;
    var v46: i32 = undefined; _ = &v46;
    var v47: i32 = undefined; _ = &v47;
    var v48: i32 = undefined; _ = &v48;
    var v49: i32 = undefined; _ = &v49;
    var v50: bool = undefined; _ = &v50;
    var v52: bool = undefined; _ = &v52;
    var v53: bool = undefined; _ = &v53;
    var v63: bool = undefined; _ = &v63;
    var v64: i32 = undefined; _ = &v64;
    var v65: bool = undefined; _ = &v65;
    var v67: i32 = undefined; _ = &v67;
    var v68: u8 = undefined; _ = &v68;
    var v69: i32 = undefined; _ = &v69;
    var v70: i32 = undefined; _ = &v70;
    var v71: u8 = undefined; _ = &v71;
    var v72: i32 = undefined; _ = &v72;
    var v73: u8 = undefined; _ = &v73;
    var v74: i32 = undefined; _ = &v74;
    var v75: bool = undefined; _ = &v75;
    var v77: bool = undefined; _ = &v77;
    var v76: bool = undefined; _ = &v76;
    var v78: bool = undefined; _ = &v78;
    var v80: bool = undefined; _ = &v80;
    var v79: bool = undefined; _ = &v79;
    var v81: bool = undefined; _ = &v81;
    var v83: bool = undefined; _ = &v83;
    var v82: bool = undefined; _ = &v82;
    var v84: i32 = undefined; _ = &v84;
    var v85: i32 = undefined; _ = &v85;
    var v86: i32 = undefined; _ = &v86;
    var v87: i32 = undefined; _ = &v87;
    var v88: i32 = undefined; _ = &v88;
    var v89: i32 = undefined; _ = &v89;
    var v90: i32 = undefined; _ = &v90;
    var v91: i32 = undefined; _ = &v91;
    var v92: i32 = undefined; _ = &v92;
    var v93: i32 = undefined; _ = &v93;
    var v94: bool = undefined; _ = &v94;
    var v96: bool = undefined; _ = &v96;
    const v2: i32 = @as(i32, @intCast(v0.len));
    const v3: bool = v1 < @as(i32, 0);
    if (v3) {
        spiralFail("UTF-8 byte offset is negative.");
    } else {
        v5 = v1 >= v2;
        if (v5) {
            spiralFail("UTF-8 byte offset is outside the string.");
        } else {
            v7 = runtime_byte_2(v0, v1);
            v8 = @as(i32, v7);
            v9 = v8 < @as(i32, 128);
            if (v9) {
                return v8;
            } else {
                v10 = v8 < @as(i32, 194);
                if (v10) {
                    spiralFail("UTF-8 scalar starts with an invalid lead byte.");
                } else {
                    v12 = v8 < @as(i32, 224);
                    if (v12) {
                        v13 = v1 +% @as(i32, 1);
                        v14 = v13 >= v2;
                        if (v14) {
                            spiralFail("UTF-8 sequence is truncated.");
                        } else {
                            v16 = runtime_byte_2(v0, v13);
                            v17 = @as(i32, v16);
                            v18 = v17 < @as(i32, 128);
                            if (v18) {
                                v20 = false;
                            } else {
                                v19 = v17 < @as(i32, 192);
                                v20 = v19;
                            }
                            if (v20) {
                                v21 = v8 -% @as(i32, 192);
                                v22 = v21 *% @as(i32, 64);
                                v23 = v17 -% @as(i32, 128);
                                v24 = v22 +% v23;
                                return v24;
                            } else {
                                spiralFail("UTF-8 sequence has an invalid continuation byte.");
                            }
                        }
                    } else {
                        v28 = v8 < @as(i32, 240);
                        if (v28) {
                            v29 = v1 +% @as(i32, 2);
                            v30 = v29 >= v2;
                            if (v30) {
                                spiralFail("UTF-8 sequence is truncated.");
                            } else {
                                v32 = v1 +% @as(i32, 1);
                                v33 = runtime_byte_2(v0, v32);
                                v34 = @as(i32, v33);
                                v35 = runtime_byte_2(v0, v29);
                                v36 = @as(i32, v35);
                                v37 = v34 < @as(i32, 128);
                                if (v37) {
                                    v39 = false;
                                } else {
                                    v38 = v34 < @as(i32, 192);
                                    v39 = v38;
                                }
                                if (v39) {
                                    v40 = v36 < @as(i32, 128);
                                    if (v40) {
                                        v42 = false;
                                    } else {
                                        v41 = v36 < @as(i32, 192);
                                        v42 = v41;
                                    }
                                    if (v42) {
                                        v43 = v8 -% @as(i32, 224);
                                        v44 = v43 *% @as(i32, 4096);
                                        v45 = v34 -% @as(i32, 128);
                                        v46 = v45 *% @as(i32, 64);
                                        v47 = v44 +% v46;
                                        v48 = v36 -% @as(i32, 128);
                                        v49 = v47 +% v48;
                                        v50 = v49 < @as(i32, 2048);
                                        if (v50) {
                                            spiralFail("UTF-8 sequence is overlong.");
                                        } else {
                                            v52 = v49 >= @as(i32, 55296);
                                            if (v52) {
                                                v53 = v49 <= @as(i32, 57343);
                                                if (v53) {
                                                    spiralFail("UTF-8 sequence encodes a surrogate.");
                                                } else {
                                                    return v49;
                                                }
                                            } else {
                                                return v49;
                                            }
                                        }
                                    } else {
                                        spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                    }
                                } else {
                                    spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                }
                            }
                        } else {
                            v63 = v8 < @as(i32, 245);
                            if (v63) {
                                v64 = v1 +% @as(i32, 3);
                                v65 = v64 >= v2;
                                if (v65) {
                                    spiralFail("UTF-8 sequence is truncated.");
                                } else {
                                    v67 = v1 +% @as(i32, 1);
                                    v68 = runtime_byte_2(v0, v67);
                                    v69 = @as(i32, v68);
                                    v70 = v1 +% @as(i32, 2);
                                    v71 = runtime_byte_2(v0, v70);
                                    v72 = @as(i32, v71);
                                    v73 = runtime_byte_2(v0, v64);
                                    v74 = @as(i32, v73);
                                    v75 = v69 < @as(i32, 128);
                                    if (v75) {
                                        v77 = false;
                                    } else {
                                        v76 = v69 < @as(i32, 192);
                                        v77 = v76;
                                    }
                                    if (v77) {
                                        v78 = v72 < @as(i32, 128);
                                        if (v78) {
                                            v80 = false;
                                        } else {
                                            v79 = v72 < @as(i32, 192);
                                            v80 = v79;
                                        }
                                        if (v80) {
                                            v81 = v74 < @as(i32, 128);
                                            if (v81) {
                                                v83 = false;
                                            } else {
                                                v82 = v74 < @as(i32, 192);
                                                v83 = v82;
                                            }
                                            if (v83) {
                                                v84 = v8 -% @as(i32, 240);
                                                v85 = v84 *% @as(i32, 262144);
                                                v86 = v69 -% @as(i32, 128);
                                                v87 = v86 *% @as(i32, 4096);
                                                v88 = v85 +% v87;
                                                v89 = v72 -% @as(i32, 128);
                                                v90 = v89 *% @as(i32, 64);
                                                v91 = v88 +% v90;
                                                v92 = v74 -% @as(i32, 128);
                                                v93 = v91 +% v92;
                                                v94 = v93 < @as(i32, 65536);
                                                if (v94) {
                                                    spiralFail("UTF-8 sequence is overlong.");
                                                } else {
                                                    v96 = v93 > @as(i32, 1114111);
                                                    if (v96) {
                                                        spiralFail("UTF-8 scalar is above U+10FFFF.");
                                                    } else {
                                                        return v93;
                                                    }
                                                }
                                            } else {
                                                spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                            }
                                        } else {
                                            spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                        }
                                    } else {
                                        spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                    }
                                }
                            } else {
                                spiralFail("UTF-8 scalar starts with an invalid lead byte.");
                            }
                        }
                    }
                }
            }
        }
    }
}
fn utf8_canonical_equal_bounded_loop_0(p0: []const u8, p1: []const u8, p2: i32, p3: i32, p4: i32, p5: i32, p6: i32, p7: i32) bool {
    var v0: []const u8 = p0; _ = &v0;
    var v1: []const u8 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: i32 = p5; _ = &v5;
    var v6: i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v76: i32 = undefined; _ = &v76;
    var v77: i32 = undefined; _ = &v77;
    var v78: i32 = undefined; _ = &v78;
    var v9: bool = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v14: i32 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v20: i32 = undefined; _ = &v20;
    var v16: bool = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v21: bool = undefined; _ = &v21;
    var v67: i32 = undefined; _ = &v67;
    var v68: i32 = undefined; _ = &v68;
    var v22: bool = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: bool = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    var v35: bool = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v69: i32 = undefined; _ = &v69;
    var v79: bool = undefined; _ = &v79;
    var v147: i32 = undefined; _ = &v147;
    var v148: i32 = undefined; _ = &v148;
    var v149: i32 = undefined; _ = &v149;
    var v80: bool = undefined; _ = &v80;
    var v81: bool = undefined; _ = &v81;
    var v85: i32 = undefined; _ = &v85;
    var v86: bool = undefined; _ = &v86;
    var v91: i32 = undefined; _ = &v91;
    var v87: bool = undefined; _ = &v87;
    var v88: bool = undefined; _ = &v88;
    var v92: bool = undefined; _ = &v92;
    var v138: i32 = undefined; _ = &v138;
    var v139: i32 = undefined; _ = &v139;
    var v93: bool = undefined; _ = &v93;
    var v94: bool = undefined; _ = &v94;
    var v95: bool = undefined; _ = &v95;
    var v96: bool = undefined; _ = &v96;
    var v97: bool = undefined; _ = &v97;
    var v98: bool = undefined; _ = &v98;
    var v99: bool = undefined; _ = &v99;
    var v100: bool = undefined; _ = &v100;
    var v101: bool = undefined; _ = &v101;
    var v102: bool = undefined; _ = &v102;
    var v103: bool = undefined; _ = &v103;
    var v104: bool = undefined; _ = &v104;
    var v105: bool = undefined; _ = &v105;
    var v106: bool = undefined; _ = &v106;
    var v107: bool = undefined; _ = &v107;
    var v140: i32 = undefined; _ = &v140;
    var v150: bool = undefined; _ = &v150;
    var v151: bool = undefined; _ = &v151;
    var v152: bool = undefined; _ = &v152;
    var v153: bool = undefined; _ = &v153;
    while (true) {
        v8 = v4 >= @as(i32, 0);
        if (v8) {
            v76 = v4;
            v77 = v2;
            v78 = @as(i32, -1);
        } else {
            v9 = v2 == v6;
            if (v9) {
                v76 = @as(i32, -1);
                v77 = v2;
                v78 = @as(i32, -1);
            } else {
                v10 = v2 > v6;
                if (v10) {
                    if (spiral_true) spiralFail("UTF-8 canonical stream offset exceeds the string.");
                } else {
                    v14 = utf8_scalar_at_byte_offset_1(v0, v2);
                    v15 = v14 < @as(i32, 128);
                    if (v15) {
                        v20 = @as(i32, 1);
                    } else {
                        v16 = v14 < @as(i32, 2048);
                        if (v16) {
                            v20 = @as(i32, 2);
                        } else {
                            v17 = v14 < @as(i32, 65536);
                            if (v17) {
                                v20 = @as(i32, 3);
                            } else {
                                v20 = @as(i32, 4);
                            }
                        }
                    }
                    v21 = v14 == @as(i32, 192);
                    if (v21) {
                        v67 = @as(i32, 65);
                        v68 = @as(i32, 768);
                    } else {
                        v22 = v14 == @as(i32, 193);
                        if (v22) {
                            v67 = @as(i32, 65);
                            v68 = @as(i32, 769);
                        } else {
                            v23 = v14 == @as(i32, 195);
                            if (v23) {
                                v67 = @as(i32, 65);
                                v68 = @as(i32, 771);
                            } else {
                                v24 = v14 == @as(i32, 196);
                                if (v24) {
                                    v67 = @as(i32, 65);
                                    v68 = @as(i32, 776);
                                } else {
                                    v25 = v14 == @as(i32, 199);
                                    if (v25) {
                                        v67 = @as(i32, 67);
                                        v68 = @as(i32, 807);
                                    } else {
                                        v26 = v14 == @as(i32, 201);
                                        if (v26) {
                                            v67 = @as(i32, 69);
                                            v68 = @as(i32, 769);
                                        } else {
                                            v27 = v14 == @as(i32, 211);
                                            if (v27) {
                                                v67 = @as(i32, 79);
                                                v68 = @as(i32, 769);
                                            } else {
                                                v28 = v14 == @as(i32, 213);
                                                if (v28) {
                                                    v67 = @as(i32, 79);
                                                    v68 = @as(i32, 771);
                                                } else {
                                                    v29 = v14 == @as(i32, 224);
                                                    if (v29) {
                                                        v67 = @as(i32, 97);
                                                        v68 = @as(i32, 768);
                                                    } else {
                                                        v30 = v14 == @as(i32, 225);
                                                        if (v30) {
                                                            v67 = @as(i32, 97);
                                                            v68 = @as(i32, 769);
                                                        } else {
                                                            v31 = v14 == @as(i32, 227);
                                                            if (v31) {
                                                                v67 = @as(i32, 97);
                                                                v68 = @as(i32, 771);
                                                            } else {
                                                                v32 = v14 == @as(i32, 228);
                                                                if (v32) {
                                                                    v67 = @as(i32, 97);
                                                                    v68 = @as(i32, 776);
                                                                } else {
                                                                    v33 = v14 == @as(i32, 231);
                                                                    if (v33) {
                                                                        v67 = @as(i32, 99);
                                                                        v68 = @as(i32, 807);
                                                                    } else {
                                                                        v34 = v14 == @as(i32, 233);
                                                                        if (v34) {
                                                                            v67 = @as(i32, 101);
                                                                            v68 = @as(i32, 769);
                                                                        } else {
                                                                            v35 = v14 == @as(i32, 243);
                                                                            if (v35) {
                                                                                v67 = @as(i32, 111);
                                                                                v68 = @as(i32, 769);
                                                                            } else {
                                                                                v36 = v14 == @as(i32, 245);
                                                                                if (v36) {
                                                                                    v67 = @as(i32, 111);
                                                                                    v68 = @as(i32, 771);
                                                                                } else {
                                                                                    v67 = v14;
                                                                                    v68 = @as(i32, -1);
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                    v69 = v2 +% v20;
                    v76 = v67;
                    v77 = v69;
                    v78 = v68;
                }
            }
        }
        v79 = v5 >= @as(i32, 0);
        if (v79) {
            v147 = v5;
            v148 = v3;
            v149 = @as(i32, -1);
        } else {
            v80 = v3 == v7;
            if (v80) {
                v147 = @as(i32, -1);
                v148 = v3;
                v149 = @as(i32, -1);
            } else {
                v81 = v3 > v7;
                if (v81) {
                    if (spiral_true) spiralFail("UTF-8 canonical stream offset exceeds the string.");
                } else {
                    v85 = utf8_scalar_at_byte_offset_1(v1, v3);
                    v86 = v85 < @as(i32, 128);
                    if (v86) {
                        v91 = @as(i32, 1);
                    } else {
                        v87 = v85 < @as(i32, 2048);
                        if (v87) {
                            v91 = @as(i32, 2);
                        } else {
                            v88 = v85 < @as(i32, 65536);
                            if (v88) {
                                v91 = @as(i32, 3);
                            } else {
                                v91 = @as(i32, 4);
                            }
                        }
                    }
                    v92 = v85 == @as(i32, 192);
                    if (v92) {
                        v138 = @as(i32, 65);
                        v139 = @as(i32, 768);
                    } else {
                        v93 = v85 == @as(i32, 193);
                        if (v93) {
                            v138 = @as(i32, 65);
                            v139 = @as(i32, 769);
                        } else {
                            v94 = v85 == @as(i32, 195);
                            if (v94) {
                                v138 = @as(i32, 65);
                                v139 = @as(i32, 771);
                            } else {
                                v95 = v85 == @as(i32, 196);
                                if (v95) {
                                    v138 = @as(i32, 65);
                                    v139 = @as(i32, 776);
                                } else {
                                    v96 = v85 == @as(i32, 199);
                                    if (v96) {
                                        v138 = @as(i32, 67);
                                        v139 = @as(i32, 807);
                                    } else {
                                        v97 = v85 == @as(i32, 201);
                                        if (v97) {
                                            v138 = @as(i32, 69);
                                            v139 = @as(i32, 769);
                                        } else {
                                            v98 = v85 == @as(i32, 211);
                                            if (v98) {
                                                v138 = @as(i32, 79);
                                                v139 = @as(i32, 769);
                                            } else {
                                                v99 = v85 == @as(i32, 213);
                                                if (v99) {
                                                    v138 = @as(i32, 79);
                                                    v139 = @as(i32, 771);
                                                } else {
                                                    v100 = v85 == @as(i32, 224);
                                                    if (v100) {
                                                        v138 = @as(i32, 97);
                                                        v139 = @as(i32, 768);
                                                    } else {
                                                        v101 = v85 == @as(i32, 225);
                                                        if (v101) {
                                                            v138 = @as(i32, 97);
                                                            v139 = @as(i32, 769);
                                                        } else {
                                                            v102 = v85 == @as(i32, 227);
                                                            if (v102) {
                                                                v138 = @as(i32, 97);
                                                                v139 = @as(i32, 771);
                                                            } else {
                                                                v103 = v85 == @as(i32, 228);
                                                                if (v103) {
                                                                    v138 = @as(i32, 97);
                                                                    v139 = @as(i32, 776);
                                                                } else {
                                                                    v104 = v85 == @as(i32, 231);
                                                                    if (v104) {
                                                                        v138 = @as(i32, 99);
                                                                        v139 = @as(i32, 807);
                                                                    } else {
                                                                        v105 = v85 == @as(i32, 233);
                                                                        if (v105) {
                                                                            v138 = @as(i32, 101);
                                                                            v139 = @as(i32, 769);
                                                                        } else {
                                                                            v106 = v85 == @as(i32, 243);
                                                                            if (v106) {
                                                                                v138 = @as(i32, 111);
                                                                                v139 = @as(i32, 769);
                                                                            } else {
                                                                                v107 = v85 == @as(i32, 245);
                                                                                if (v107) {
                                                                                    v138 = @as(i32, 111);
                                                                                    v139 = @as(i32, 771);
                                                                                } else {
                                                                                    v138 = v85;
                                                                                    v139 = @as(i32, -1);
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                    v140 = v3 +% v91;
                    v147 = v138;
                    v148 = v140;
                    v149 = v139;
                }
            }
        }
        v150 = v76 < @as(i32, 0);
        if (v150) {
            v151 = v147 == @as(i32, -1);
            return v151;
        } else {
            v152 = v147 < @as(i32, 0);
            if (v152) {
                return false;
            } else {
                v153 = v76 == v147;
                if (v153) {
                    v2 = v77;
                    v3 = v148;
                    v4 = v78;
                    v5 = v149;
                    continue;
                } else {
                    return false;
                }
            }
        }
    }
}
fn spiralMain() i32 {
    const v0: []const u8 = "plain";
    const v1: i32 = @as(i32, 0);
    const v2: i32 = @as(i32, 0);
    const v3: i32 = @as(i32, -1);
    const v4: i32 = @as(i32, -1);
    const v5: i32 = @as(i32, 5);
    const v6: i32 = @as(i32, 5);
    const v7: bool = utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6);
    const v8: []const u8 = "";
    const v9: i32 = @as(i32, 0);
    const v10: i32 = @as(i32, 0);
    const v11: i32 = @as(i32, -1);
    const v12: i32 = @as(i32, -1);
    const v13: i32 = @as(i32, 0);
    const v14: i32 = @as(i32, 0);
    const v15: bool = utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14);
    const v16: []const u8 = "\xc3\xa9\xc3\xb5\xc3\xa7";
    const v17: []const u8 = "e\xcc\x81o\xcc\x83c\xcc\xa7";
    const v18: i32 = @as(i32, 0);
    const v19: i32 = @as(i32, 0);
    const v20: i32 = @as(i32, -1);
    const v21: i32 = @as(i32, -1);
    const v22: i32 = @as(i32, 6);
    const v23: i32 = @as(i32, 9);
    const v24: bool = utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23);
    const v25: []const u8 = "\xc3\xa9\xcc\x83";
    const v26: []const u8 = "e\xcc\x81\xcc\x83";
    const v27: i32 = @as(i32, 0);
    const v28: i32 = @as(i32, 0);
    const v29: i32 = @as(i32, -1);
    const v30: i32 = @as(i32, -1);
    const v31: i32 = @as(i32, 4);
    const v32: i32 = @as(i32, 5);
    const v33: bool = utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32);
    const v34: []const u8 = "\xc3\x80";
    const v35: []const u8 = "A\xcc\x80";
    const v36: i32 = @as(i32, 0);
    const v37: i32 = @as(i32, 0);
    const v38: i32 = @as(i32, -1);
    const v39: i32 = @as(i32, -1);
    const v40: i32 = @as(i32, 2);
    const v41: i32 = @as(i32, 3);
    const v42: bool = utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41);
    const v43: []const u8 = "\xce\xa9";
    const v44: i32 = @as(i32, 0);
    const v45: i32 = @as(i32, 0);
    const v46: i32 = @as(i32, -1);
    const v47: i32 = @as(i32, -1);
    const v48: i32 = @as(i32, 2);
    const v49: i32 = @as(i32, 2);
    const v50: bool = utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49);
    const v51: []const u8 = "e\xcc\x83\xcc\x81";
    const v52: i32 = @as(i32, 0);
    const v53: i32 = @as(i32, 0);
    const v54: i32 = @as(i32, -1);
    const v55: i32 = @as(i32, -1);
    const v56: i32 = @as(i32, 5);
    const v57: i32 = @as(i32, 5);
    const v58: bool = utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57);
    const v59: []const u8 = "\xc3\xa9";
    const v60: []const u8 = "\xc3\xa1";
    const v61: i32 = @as(i32, 0);
    const v62: i32 = @as(i32, 0);
    const v63: i32 = @as(i32, -1);
    const v64: i32 = @as(i32, -1);
    const v65: i32 = @as(i32, 2);
    const v66: i32 = @as(i32, 2);
    const v67: bool = utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66);
    const v68: []const u8 = "\xcf\x89";
    const v69: i32 = @as(i32, 0);
    const v70: i32 = @as(i32, 0);
    const v71: i32 = @as(i32, -1);
    const v72: i32 = @as(i32, -1);
    const v73: i32 = @as(i32, 2);
    const v74: i32 = @as(i32, 2);
    const v75: bool = utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74);
    const v76: []const u8 = "e";
    const v77: i32 = @as(i32, 0);
    const v78: i32 = @as(i32, 0);
    const v79: i32 = @as(i32, -1);
    const v80: i32 = @as(i32, -1);
    const v81: i32 = @as(i32, 2);
    const v82: i32 = @as(i32, 1);
    const v83: bool = utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82);
    if (v7) {
        if (v15) {
            if (v24) {
                if (v33) {
                    if (v42) {
                        if (v50) {
                            if (v58) {
                                return @as(i32, 7);
                            } else {
                                if (v67) {
                                    return @as(i32, 8);
                                } else {
                                    if (v75) {
                                        return @as(i32, 9);
                                    } else {
                                        if (v83) {
                                            return @as(i32, 10);
                                        } else {
                                            return @as(i32, 0);
                                        }
                                    }
                                }
                            }
                        } else {
                            return @as(i32, 6);
                        }
                    } else {
                        return @as(i32, 5);
                    }
                } else {
                    return @as(i32, 4);
                }
            } else {
                return @as(i32, 3);
            }
        } else {
            return @as(i32, 2);
        }
    } else {
        return @as(i32, 1);
    }
}
var spiral_exit_code: i32 = 0;
fn spiralMainThread() void {
    spiral_exit_code = spiralMain();
}
extern "kernel32" fn CreateThread(attributes: ?*anyopaque, stack_size: usize, start: *const fn (?*anyopaque) callconv(.winapi) u32, parameter: ?*anyopaque, flags: u32, id: ?*u32) callconv(.winapi) ?std.os.windows.HANDLE;
extern "kernel32" fn WaitForSingleObject(handle: std.os.windows.HANDLE, milliseconds: u32) callconv(.winapi) u32;
extern "kernel32" fn ExitProcess(code: u32) callconv(.winapi) noreturn;
fn spiralMainThreadReserved(_: ?*anyopaque) callconv(.winapi) u32 {
    spiralMainThread();
    return 0;
}
pub fn main(init: std.process.Init.Minimal) void {
    spiral_gpa = spiral_arena.allocator();
    spiral_environ = init.environ;
    if (@import("builtin").os.tag == .windows) {
        const handle = CreateThread(null, 1 << 30, spiralMainThreadReserved, null, 0x00010000, null) orelse @panic("spiral: could not start the main thread");
        _ = WaitForSingleObject(handle, 0xFFFFFFFF);
    } else {
        const thread = std.Thread.spawn(.{ .stack_size = 1 << 30 }, spiralMainThread, .{}) catch @panic("spiral: could not start the main thread");
        thread.join();
    }
    spiralFlush();
    if (@import("builtin").os.tag == .windows) ExitProcess(@bitCast(spiral_exit_code)) else std.process.exit(@truncate(@as(u32, @bitCast(spiral_exit_code))));
}
