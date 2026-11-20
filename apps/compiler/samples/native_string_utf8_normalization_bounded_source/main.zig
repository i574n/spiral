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
fn runtime_byte_1(p0: []const u8, p1: i32) u8 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    const v2: u8 = v0[spiralIndex(v0.len, v1)];
    return v2;
}
fn utf8_scalar_at_byte_offset_0(p0: []const u8, p1: i32) i32 {
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
            v7 = runtime_byte_1(v0, v1);
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
                            v16 = runtime_byte_1(v0, v13);
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
                                v33 = runtime_byte_1(v0, v32);
                                v34 = @as(i32, v33);
                                v35 = runtime_byte_1(v0, v29);
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
                                    v68 = runtime_byte_1(v0, v67);
                                    v69 = @as(i32, v68);
                                    v70 = v1 +% @as(i32, 2);
                                    v71 = runtime_byte_1(v0, v70);
                                    v72 = @as(i32, v71);
                                    v73 = runtime_byte_1(v0, v64);
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
fn spiralMain() i32 {
    var v64: i32 = undefined; _ = &v64;
    var v65: i32 = undefined; _ = &v65;
    var v19: bool = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
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
    var v112: i32 = undefined; _ = &v112;
    var v113: i32 = undefined; _ = &v113;
    var v67: bool = undefined; _ = &v67;
    var v68: bool = undefined; _ = &v68;
    var v69: bool = undefined; _ = &v69;
    var v70: bool = undefined; _ = &v70;
    var v71: bool = undefined; _ = &v71;
    var v72: bool = undefined; _ = &v72;
    var v73: bool = undefined; _ = &v73;
    var v74: bool = undefined; _ = &v74;
    var v75: bool = undefined; _ = &v75;
    var v76: bool = undefined; _ = &v76;
    var v77: bool = undefined; _ = &v77;
    var v78: bool = undefined; _ = &v78;
    var v79: bool = undefined; _ = &v79;
    var v80: bool = undefined; _ = &v80;
    var v81: bool = undefined; _ = &v81;
    var v160: i32 = undefined; _ = &v160;
    var v161: i32 = undefined; _ = &v161;
    var v115: bool = undefined; _ = &v115;
    var v116: bool = undefined; _ = &v116;
    var v117: bool = undefined; _ = &v117;
    var v118: bool = undefined; _ = &v118;
    var v119: bool = undefined; _ = &v119;
    var v120: bool = undefined; _ = &v120;
    var v121: bool = undefined; _ = &v121;
    var v122: bool = undefined; _ = &v122;
    var v123: bool = undefined; _ = &v123;
    var v124: bool = undefined; _ = &v124;
    var v125: bool = undefined; _ = &v125;
    var v126: bool = undefined; _ = &v126;
    var v127: bool = undefined; _ = &v127;
    var v128: bool = undefined; _ = &v128;
    var v129: bool = undefined; _ = &v129;
    var v163: i32 = undefined; _ = &v163;
    var v165: i32 = undefined; _ = &v165;
    var v166: i32 = undefined; _ = &v166;
    var v170: i32 = undefined; _ = &v170;
    var v168: bool = undefined; _ = &v168;
    var v172: i32 = undefined; _ = &v172;
    var v173: i32 = undefined; _ = &v173;
    var v175: i32 = undefined; _ = &v175;
    var v177: i32 = undefined; _ = &v177;
    var v178: i32 = undefined; _ = &v178;
    var v181: bool = undefined; _ = &v181;
    var v180: bool = undefined; _ = &v180;
    var v182: bool = undefined; _ = &v182;
    var v184: bool = undefined; _ = &v184;
    var v183: bool = undefined; _ = &v183;
    var v185: bool = undefined; _ = &v185;
    var v187: bool = undefined; _ = &v187;
    var v186: bool = undefined; _ = &v186;
    var v188: bool = undefined; _ = &v188;
    var v190: bool = undefined; _ = &v190;
    var v189: bool = undefined; _ = &v189;
    var v191: bool = undefined; _ = &v191;
    var v193: bool = undefined; _ = &v193;
    var v192: bool = undefined; _ = &v192;
    var v194: bool = undefined; _ = &v194;
    var v196: bool = undefined; _ = &v196;
    var v195: bool = undefined; _ = &v195;
    const v0: []const u8 = "\xc3\xa9";
    const v1: i32 = @as(i32, 0);
    const v2: i32 = utf8_scalar_at_byte_offset_0(v0, v1);
    const v3: []const u8 = "\xc3\xb5";
    const v4: i32 = @as(i32, 0);
    const v5: i32 = utf8_scalar_at_byte_offset_0(v3, v4);
    const v6: []const u8 = "\xc3\xa7";
    const v7: i32 = @as(i32, 0);
    const v8: i32 = utf8_scalar_at_byte_offset_0(v6, v7);
    const v9: []const u8 = "\xcc\x81";
    const v10: i32 = @as(i32, 0);
    const v11: i32 = utf8_scalar_at_byte_offset_0(v9, v10);
    const v12: []const u8 = "\xcc\x83";
    const v13: i32 = @as(i32, 0);
    const v14: i32 = utf8_scalar_at_byte_offset_0(v12, v13);
    const v15: []const u8 = "\xcc\xa7";
    const v16: i32 = @as(i32, 0);
    const v17: i32 = utf8_scalar_at_byte_offset_0(v15, v16);
    const v18: bool = v2 == @as(i32, 192);
    if (v18) {
        v64 = @as(i32, 65);
        v65 = @as(i32, 768);
    } else {
        v19 = v2 == @as(i32, 193);
        if (v19) {
            v64 = @as(i32, 65);
            v65 = @as(i32, 769);
        } else {
            v20 = v2 == @as(i32, 195);
            if (v20) {
                v64 = @as(i32, 65);
                v65 = @as(i32, 771);
            } else {
                v21 = v2 == @as(i32, 196);
                if (v21) {
                    v64 = @as(i32, 65);
                    v65 = @as(i32, 776);
                } else {
                    v22 = v2 == @as(i32, 199);
                    if (v22) {
                        v64 = @as(i32, 67);
                        v65 = @as(i32, 807);
                    } else {
                        v23 = v2 == @as(i32, 201);
                        if (v23) {
                            v64 = @as(i32, 69);
                            v65 = @as(i32, 769);
                        } else {
                            v24 = v2 == @as(i32, 211);
                            if (v24) {
                                v64 = @as(i32, 79);
                                v65 = @as(i32, 769);
                            } else {
                                v25 = v2 == @as(i32, 213);
                                if (v25) {
                                    v64 = @as(i32, 79);
                                    v65 = @as(i32, 771);
                                } else {
                                    v26 = v2 == @as(i32, 224);
                                    if (v26) {
                                        v64 = @as(i32, 97);
                                        v65 = @as(i32, 768);
                                    } else {
                                        v27 = v2 == @as(i32, 225);
                                        if (v27) {
                                            v64 = @as(i32, 97);
                                            v65 = @as(i32, 769);
                                        } else {
                                            v28 = v2 == @as(i32, 227);
                                            if (v28) {
                                                v64 = @as(i32, 97);
                                                v65 = @as(i32, 771);
                                            } else {
                                                v29 = v2 == @as(i32, 228);
                                                if (v29) {
                                                    v64 = @as(i32, 97);
                                                    v65 = @as(i32, 776);
                                                } else {
                                                    v30 = v2 == @as(i32, 231);
                                                    if (v30) {
                                                        v64 = @as(i32, 99);
                                                        v65 = @as(i32, 807);
                                                    } else {
                                                        v31 = v2 == @as(i32, 233);
                                                        if (v31) {
                                                            v64 = @as(i32, 101);
                                                            v65 = @as(i32, 769);
                                                        } else {
                                                            v32 = v2 == @as(i32, 243);
                                                            if (v32) {
                                                                v64 = @as(i32, 111);
                                                                v65 = @as(i32, 769);
                                                            } else {
                                                                v33 = v2 == @as(i32, 245);
                                                                if (v33) {
                                                                    v64 = @as(i32, 111);
                                                                    v65 = @as(i32, 771);
                                                                } else {
                                                                    v64 = v2;
                                                                    v65 = @as(i32, -1);
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
    const v66: bool = v5 == @as(i32, 192);
    if (v66) {
        v112 = @as(i32, 65);
        v113 = @as(i32, 768);
    } else {
        v67 = v5 == @as(i32, 193);
        if (v67) {
            v112 = @as(i32, 65);
            v113 = @as(i32, 769);
        } else {
            v68 = v5 == @as(i32, 195);
            if (v68) {
                v112 = @as(i32, 65);
                v113 = @as(i32, 771);
            } else {
                v69 = v5 == @as(i32, 196);
                if (v69) {
                    v112 = @as(i32, 65);
                    v113 = @as(i32, 776);
                } else {
                    v70 = v5 == @as(i32, 199);
                    if (v70) {
                        v112 = @as(i32, 67);
                        v113 = @as(i32, 807);
                    } else {
                        v71 = v5 == @as(i32, 201);
                        if (v71) {
                            v112 = @as(i32, 69);
                            v113 = @as(i32, 769);
                        } else {
                            v72 = v5 == @as(i32, 211);
                            if (v72) {
                                v112 = @as(i32, 79);
                                v113 = @as(i32, 769);
                            } else {
                                v73 = v5 == @as(i32, 213);
                                if (v73) {
                                    v112 = @as(i32, 79);
                                    v113 = @as(i32, 771);
                                } else {
                                    v74 = v5 == @as(i32, 224);
                                    if (v74) {
                                        v112 = @as(i32, 97);
                                        v113 = @as(i32, 768);
                                    } else {
                                        v75 = v5 == @as(i32, 225);
                                        if (v75) {
                                            v112 = @as(i32, 97);
                                            v113 = @as(i32, 769);
                                        } else {
                                            v76 = v5 == @as(i32, 227);
                                            if (v76) {
                                                v112 = @as(i32, 97);
                                                v113 = @as(i32, 771);
                                            } else {
                                                v77 = v5 == @as(i32, 228);
                                                if (v77) {
                                                    v112 = @as(i32, 97);
                                                    v113 = @as(i32, 776);
                                                } else {
                                                    v78 = v5 == @as(i32, 231);
                                                    if (v78) {
                                                        v112 = @as(i32, 99);
                                                        v113 = @as(i32, 807);
                                                    } else {
                                                        v79 = v5 == @as(i32, 233);
                                                        if (v79) {
                                                            v112 = @as(i32, 101);
                                                            v113 = @as(i32, 769);
                                                        } else {
                                                            v80 = v5 == @as(i32, 243);
                                                            if (v80) {
                                                                v112 = @as(i32, 111);
                                                                v113 = @as(i32, 769);
                                                            } else {
                                                                v81 = v5 == @as(i32, 245);
                                                                if (v81) {
                                                                    v112 = @as(i32, 111);
                                                                    v113 = @as(i32, 771);
                                                                } else {
                                                                    v112 = v5;
                                                                    v113 = @as(i32, -1);
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
    const v114: bool = v8 == @as(i32, 192);
    if (v114) {
        v160 = @as(i32, 65);
        v161 = @as(i32, 768);
    } else {
        v115 = v8 == @as(i32, 193);
        if (v115) {
            v160 = @as(i32, 65);
            v161 = @as(i32, 769);
        } else {
            v116 = v8 == @as(i32, 195);
            if (v116) {
                v160 = @as(i32, 65);
                v161 = @as(i32, 771);
            } else {
                v117 = v8 == @as(i32, 196);
                if (v117) {
                    v160 = @as(i32, 65);
                    v161 = @as(i32, 776);
                } else {
                    v118 = v8 == @as(i32, 199);
                    if (v118) {
                        v160 = @as(i32, 67);
                        v161 = @as(i32, 807);
                    } else {
                        v119 = v8 == @as(i32, 201);
                        if (v119) {
                            v160 = @as(i32, 69);
                            v161 = @as(i32, 769);
                        } else {
                            v120 = v8 == @as(i32, 211);
                            if (v120) {
                                v160 = @as(i32, 79);
                                v161 = @as(i32, 769);
                            } else {
                                v121 = v8 == @as(i32, 213);
                                if (v121) {
                                    v160 = @as(i32, 79);
                                    v161 = @as(i32, 771);
                                } else {
                                    v122 = v8 == @as(i32, 224);
                                    if (v122) {
                                        v160 = @as(i32, 97);
                                        v161 = @as(i32, 768);
                                    } else {
                                        v123 = v8 == @as(i32, 225);
                                        if (v123) {
                                            v160 = @as(i32, 97);
                                            v161 = @as(i32, 769);
                                        } else {
                                            v124 = v8 == @as(i32, 227);
                                            if (v124) {
                                                v160 = @as(i32, 97);
                                                v161 = @as(i32, 771);
                                            } else {
                                                v125 = v8 == @as(i32, 228);
                                                if (v125) {
                                                    v160 = @as(i32, 97);
                                                    v161 = @as(i32, 776);
                                                } else {
                                                    v126 = v8 == @as(i32, 231);
                                                    if (v126) {
                                                        v160 = @as(i32, 99);
                                                        v161 = @as(i32, 807);
                                                    } else {
                                                        v127 = v8 == @as(i32, 233);
                                                        if (v127) {
                                                            v160 = @as(i32, 101);
                                                            v161 = @as(i32, 769);
                                                        } else {
                                                            v128 = v8 == @as(i32, 243);
                                                            if (v128) {
                                                                v160 = @as(i32, 111);
                                                                v161 = @as(i32, 769);
                                                            } else {
                                                                v129 = v8 == @as(i32, 245);
                                                                if (v129) {
                                                                    v160 = @as(i32, 111);
                                                                    v161 = @as(i32, 771);
                                                                } else {
                                                                    v160 = v8;
                                                                    v161 = @as(i32, -1);
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
    const v162: bool = v11 == @as(i32, 769);
    if (v162) {
        v163 = @as(i32, 233);
    } else {
        v163 = @as(i32, -1);
    }
    const v164: bool = v163 < @as(i32, 0);
    if (v164) {
        v165 = @as(i32, 101);
        v166 = v11;
    } else {
        v165 = v163;
        v166 = @as(i32, -1);
    }
    const v167: bool = v14 == @as(i32, 769);
    if (v167) {
        v170 = @as(i32, 243);
    } else {
        v168 = v14 == @as(i32, 771);
        if (v168) {
            v170 = @as(i32, 245);
        } else {
            v170 = @as(i32, -1);
        }
    }
    const v171: bool = v170 < @as(i32, 0);
    if (v171) {
        v172 = @as(i32, 111);
        v173 = v14;
    } else {
        v172 = v170;
        v173 = @as(i32, -1);
    }
    const v174: bool = v17 == @as(i32, 807);
    if (v174) {
        v175 = @as(i32, 231);
    } else {
        v175 = @as(i32, -1);
    }
    const v176: bool = v175 < @as(i32, 0);
    if (v176) {
        v177 = @as(i32, 99);
        v178 = v17;
    } else {
        v177 = v175;
        v178 = @as(i32, -1);
    }
    const v179: bool = v64 == @as(i32, 101);
    if (v179) {
        v180 = v65 == v11;
        v181 = v180;
    } else {
        v181 = false;
    }
    if (v181) {
        v182 = v112 == @as(i32, 111);
        if (v182) {
            v183 = v113 == v14;
            v184 = v183;
        } else {
            v184 = false;
        }
        if (v184) {
            v185 = v160 == @as(i32, 99);
            if (v185) {
                v186 = v161 == v17;
                v187 = v186;
            } else {
                v187 = false;
            }
            if (v187) {
                v188 = v165 == v2;
                if (v188) {
                    v189 = v166 == @as(i32, -1);
                    v190 = v189;
                } else {
                    v190 = false;
                }
                if (v190) {
                    v191 = v172 == v5;
                    if (v191) {
                        v192 = v173 == @as(i32, -1);
                        v193 = v192;
                    } else {
                        v193 = false;
                    }
                    if (v193) {
                        v194 = v177 == v8;
                        if (v194) {
                            v195 = v178 == @as(i32, -1);
                            v196 = v195;
                        } else {
                            v196 = false;
                        }
                        if (v196) {
                            return @as(i32, 0);
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
