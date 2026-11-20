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
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const US0 = struct { tag: i32 };
const UH0 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH0 = undefined, c3_1: *UH0 = undefined, c4_0: *UH0 = undefined, c4_1: *UH0 = undefined, c5_0: *UH0 = undefined };
const US1 = struct { tag: i32 };
const UH1 = struct { tag: i32, c0_0: US0 = undefined, c1_0: US0 = undefined, c2_0: US0 = undefined, c2_1: US0 = undefined, c3_0: US0 = undefined, c3_1: *UH1 = undefined, c3_2: *UH1 = undefined, c4_0: US0 = undefined, c4_1: US1 = undefined, c4_2: *UH1 = undefined, c4_3: *UH1 = undefined, c5_0: US0 = undefined, c5_1: *UH1 = undefined };
const US2 = struct { tag: i32 };
const US3 = struct { tag: i32 };
const UH2 = struct { tag: i32, c2_0: US3 = undefined, c3_0: *UH2 = undefined, c3_1: *UH2 = undefined, c4_0: *UH2 = undefined, c4_1: *UH2 = undefined, c5_0: *UH2 = undefined };
const UH3 = struct { tag: i32, c0_0: US3 = undefined, c1_0: US3 = undefined, c2_0: US3 = undefined, c2_1: US3 = undefined, c3_0: US3 = undefined, c3_1: *UH3 = undefined, c3_2: *UH3 = undefined, c4_0: US3 = undefined, c4_1: US1 = undefined, c4_2: *UH3 = undefined, c4_3: *UH3 = undefined, c5_0: US3 = undefined, c5_1: *UH3 = undefined };
const US4 = struct { tag: i32 };
const UH4 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH4 = undefined };
const UH6 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH6 = undefined };
const UH5 = struct { tag: i32, c1_0: *UH6 = undefined, c1_1: *UH5 = undefined };
const UH7 = struct { tag: i32, c1_0: US3 = undefined, c1_1: *UH7 = undefined };
const UH9 = struct { tag: i32, c1_0: US3 = undefined, c1_1: *UH9 = undefined };
const UH8 = struct { tag: i32, c1_0: *UH9 = undefined, c1_1: *UH8 = undefined };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH6) bool };
const ClosureEnv0 = struct { v0: bool, v1: *UH0, pad: u8 = 0 };
const Tuple0 = struct { f0: *UH5, f1: *UH5 };
const Fun1 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH9) bool };
const ClosureEnv1 = struct { v0: bool, v1: *UH2, pad: u8 = 0 };
const Tuple1 = struct { f0: *UH8, f1: *UH8 };
fn US0_BitZero() US0 {
    return US0{ .tag = 0 };
}
fn US0_BitOne() US0 {
    return US0{ .tag = 1 };
}
fn UH0_RegexEmpty() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_RegexEpsilon() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 1 };
    };
    return &shared.value;
}
fn UH0_RegexChar(a0: US0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 2, .c2_0 = a0 });
}
fn UH0_RegexAlt(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH0_RegexCat(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH0_RegexStar(a0: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 5, .c5_0 = a0 });
}
fn US1_EquationCatNullable() US1 {
    return US1{ .tag = 0 };
}
fn US1_EquationCatNonNullable() US1 {
    return US1{ .tag = 1 };
}
fn UH1_DerivativeEquationProofEmpty(a0: US0) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 0, .c0_0 = a0 });
}
fn UH1_DerivativeEquationProofEpsilon(a0: US0) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0 });
}
fn UH1_DerivativeEquationProofChar(a0: US0, a1: US0) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 2, .c2_0 = a0, .c2_1 = a1 });
}
fn UH1_DerivativeEquationProofAlt(a0: US0, a1: *UH1, a2: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 3, .c3_0 = a0, .c3_1 = a1, .c3_2 = a2 });
}
fn UH1_DerivativeEquationProofCat(a0: US0, a1: US1, a2: *UH1, a3: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 4, .c4_0 = a0, .c4_1 = a1, .c4_2 = a2, .c4_3 = a3 });
}
fn UH1_DerivativeEquationProofStar(a0: US0, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 5, .c5_0 = a0, .c5_1 = a1 });
}
fn US2_Nullable() US2 {
    return US2{ .tag = 0 };
}
fn US2_NonNullable() US2 {
    return US2{ .tag = 1 };
}
fn nullable_1(p0: *UH0) US2 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH0 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_1(v5);
            v8 = nullable_1(v6);
            switch (v7.tag) {
                0 => {
                    return US2_Nullable();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US2_NonNullable();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
        },
        4 => {
            v16 = v0.c4_0;
            v17 = v0.c4_1;
            v18 = nullable_1(v16);
            v19 = nullable_1(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            return US2_NonNullable();
                        },
                    }
                },
                else => {
                    return US2_NonNullable();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US2_NonNullable();
        },
        0 => {
            return US2_NonNullable();
        },
        1 => {
            return US2_Nullable();
        },
        5 => {
            v25 = v0.c5_0;
            return US2_Nullable();
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_make_0(p0: *UH0, p1: US0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: US2 = undefined; _ = &v13;
    var v17: US1 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
    var v19: *UH1 = undefined; _ = &v19;
    var v4: US0 = undefined; _ = &v4;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH1 = undefined; _ = &v22;
    switch (v0.tag) {
        3 => {
            v6 = v0.c3_0;
            v7 = v0.c3_1;
            v8 = derivative_equation_proof_make_0(v6, v1);
            v9 = derivative_equation_proof_make_0(v7, v1);
            return UH1_DerivativeEquationProofAlt(v1, v8, v9);
        },
        4 => {
            v11 = v0.c4_0;
            v12 = v0.c4_1;
            v13 = nullable_1(v11);
            switch (v13.tag) {
                1 => {
                    v17 = US1_EquationCatNonNullable();
                },
                0 => {
                    v17 = US1_EquationCatNullable();
                },
                else => unreachable,
            }
            v18 = derivative_equation_proof_make_0(v11, v1);
            v19 = derivative_equation_proof_make_0(v12, v1);
            return UH1_DerivativeEquationProofCat(v1, v17, v18, v19);
        },
        2 => {
            v4 = v0.c2_0;
            return UH1_DerivativeEquationProofChar(v4, v1);
        },
        0 => {
            return UH1_DerivativeEquationProofEmpty(v1);
        },
        1 => {
            return UH1_DerivativeEquationProofEpsilon(v1);
        },
        5 => {
            v21 = v0.c5_0;
            v22 = derivative_equation_proof_make_0(v21, v1);
            return UH1_DerivativeEquationProofStar(v1, v22);
        },
        else => unreachable,
    }
}
fn US3_TriA() US3 {
    return US3{ .tag = 0 };
}
fn US3_TriB() US3 {
    return US3{ .tag = 1 };
}
fn US3_TriC() US3 {
    return US3{ .tag = 2 };
}
fn UH2_RegexEmpty() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_RegexEpsilon() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 1 };
    };
    return &shared.value;
}
fn UH2_RegexChar(a0: US3) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 2, .c2_0 = a0 });
}
fn UH2_RegexAlt(a0: *UH2, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH2_RegexCat(a0: *UH2, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH2_RegexStar(a0: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 5, .c5_0 = a0 });
}
fn UH3_DerivativeEquationProofEmpty(a0: US3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 0, .c0_0 = a0 });
}
fn UH3_DerivativeEquationProofEpsilon(a0: US3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0 });
}
fn UH3_DerivativeEquationProofChar(a0: US3, a1: US3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 2, .c2_0 = a0, .c2_1 = a1 });
}
fn UH3_DerivativeEquationProofAlt(a0: US3, a1: *UH3, a2: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 3, .c3_0 = a0, .c3_1 = a1, .c3_2 = a2 });
}
fn UH3_DerivativeEquationProofCat(a0: US3, a1: US1, a2: *UH3, a3: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 4, .c4_0 = a0, .c4_1 = a1, .c4_2 = a2, .c4_3 = a3 });
}
fn UH3_DerivativeEquationProofStar(a0: US3, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 5, .c5_0 = a0, .c5_1 = a1 });
}
fn nullable_3(p0: *UH2) US2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US3 = undefined; _ = &v3;
    var v25: *UH2 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_3(v5);
            v8 = nullable_3(v6);
            switch (v7.tag) {
                0 => {
                    return US2_Nullable();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US2_NonNullable();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
        },
        4 => {
            v16 = v0.c4_0;
            v17 = v0.c4_1;
            v18 = nullable_3(v16);
            v19 = nullable_3(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            return US2_NonNullable();
                        },
                    }
                },
                else => {
                    return US2_NonNullable();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US2_NonNullable();
        },
        0 => {
            return US2_NonNullable();
        },
        1 => {
            return US2_Nullable();
        },
        5 => {
            v25 = v0.c5_0;
            return US2_Nullable();
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_make_2(p0: *UH2, p1: US3) *UH3 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH3 = undefined; _ = &v8;
    var v9: *UH3 = undefined; _ = &v9;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: US2 = undefined; _ = &v13;
    var v17: US1 = undefined; _ = &v17;
    var v18: *UH3 = undefined; _ = &v18;
    var v19: *UH3 = undefined; _ = &v19;
    var v4: US3 = undefined; _ = &v4;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: *UH3 = undefined; _ = &v22;
    switch (v0.tag) {
        3 => {
            v6 = v0.c3_0;
            v7 = v0.c3_1;
            v8 = derivative_equation_proof_make_2(v6, v1);
            v9 = derivative_equation_proof_make_2(v7, v1);
            return UH3_DerivativeEquationProofAlt(v1, v8, v9);
        },
        4 => {
            v11 = v0.c4_0;
            v12 = v0.c4_1;
            v13 = nullable_3(v11);
            switch (v13.tag) {
                1 => {
                    v17 = US1_EquationCatNonNullable();
                },
                0 => {
                    v17 = US1_EquationCatNullable();
                },
                else => unreachable,
            }
            v18 = derivative_equation_proof_make_2(v11, v1);
            v19 = derivative_equation_proof_make_2(v12, v1);
            return UH3_DerivativeEquationProofCat(v1, v17, v18, v19);
        },
        2 => {
            v4 = v0.c2_0;
            return UH3_DerivativeEquationProofChar(v4, v1);
        },
        0 => {
            return UH3_DerivativeEquationProofEmpty(v1);
        },
        1 => {
            return UH3_DerivativeEquationProofEpsilon(v1);
        },
        5 => {
            v21 = v0.c5_0;
            v22 = derivative_equation_proof_make_2(v21, v1);
            return UH3_DerivativeEquationProofStar(v1, v22);
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_source_5(p0: *UH1) *UH0 {
    var v0: *UH1 = p0; _ = &v0;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v10: *UH1 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v14: US0 = undefined; _ = &v14;
    var v15: US1 = undefined; _ = &v15;
    var v16: *UH1 = undefined; _ = &v16;
    var v17: *UH1 = undefined; _ = &v17;
    var v18: *UH0 = undefined; _ = &v18;
    var v19: *UH0 = undefined; _ = &v19;
    var v5: US0 = undefined; _ = &v5;
    var v6: US0 = undefined; _ = &v6;
    var v1: US0 = undefined; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v21: US0 = undefined; _ = &v21;
    var v22: *UH1 = undefined; _ = &v22;
    var v23: *UH0 = undefined; _ = &v23;
    switch (v0.tag) {
        3 => {
            v8 = v0.c3_0;
            v9 = v0.c3_1;
            v10 = v0.c3_2;
            v11 = derivative_equation_proof_source_5(v9);
            v12 = derivative_equation_proof_source_5(v10);
            return UH0_RegexAlt(v11, v12);
        },
        4 => {
            v14 = v0.c4_0;
            v15 = v0.c4_1;
            v16 = v0.c4_2;
            v17 = v0.c4_3;
            v18 = derivative_equation_proof_source_5(v16);
            v19 = derivative_equation_proof_source_5(v17);
            return UH0_RegexCat(v18, v19);
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            return UH0_RegexChar(v5);
        },
        0 => {
            v1 = v0.c0_0;
            return UH0_RegexEmpty();
        },
        1 => {
            v3 = v0.c1_0;
            return UH0_RegexEpsilon();
        },
        5 => {
            v21 = v0.c5_0;
            v22 = v0.c5_1;
            v23 = derivative_equation_proof_source_5(v22);
            return UH0_RegexStar(v23);
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_symbol_6(p0: *UH1) US0 {
    var v0: *UH1 = p0; _ = &v0;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: US0 = undefined; _ = &v8;
    var v9: US1 = undefined; _ = &v9;
    var v10: *UH1 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v3: US0 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v1: US0 = undefined; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = v0.c3_2;
            return v5;
        },
        4 => {
            v8 = v0.c4_0;
            v9 = v0.c4_1;
            v10 = v0.c4_2;
            v11 = v0.c4_3;
            return v8;
        },
        2 => {
            v3 = v0.c2_0;
            v4 = v0.c2_1;
            return v4;
        },
        0 => {
            v1 = v0.c0_0;
            return v1;
        },
        1 => {
            v2 = v0.c1_0;
            return v2;
        },
        5 => {
            v12 = v0.c5_0;
            v13 = v0.c5_1;
            return v12;
        },
        else => unreachable,
    }
}
fn US4_SymbolLess() US4 {
    return US4{ .tag = 0 };
}
fn US4_SymbolSame() US4 {
    return US4{ .tag = 1 };
}
fn US4_SymbolGreater() US4 {
    return US4{ .tag = 2 };
}
fn derivative_equation_proof_candidate_7(p0: *UH1) *UH0 {
    var v0: *UH1 = p0; _ = &v0;
    var v21: US0 = undefined; _ = &v21;
    var v22: *UH1 = undefined; _ = &v22;
    var v23: *UH1 = undefined; _ = &v23;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v27: US0 = undefined; _ = &v27;
    var v28: US1 = undefined; _ = &v28;
    var v29: *UH1 = undefined; _ = &v29;
    var v30: *UH1 = undefined; _ = &v30;
    var v31: *UH0 = undefined; _ = &v31;
    var v32: *UH0 = undefined; _ = &v32;
    var v33: *UH0 = undefined; _ = &v33;
    var v34: *UH0 = undefined; _ = &v34;
    var v5: US0 = undefined; _ = &v5;
    var v6: US0 = undefined; _ = &v6;
    var v16: US4 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v1: US0 = undefined; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v39: US0 = undefined; _ = &v39;
    var v40: *UH1 = undefined; _ = &v40;
    var v41: *UH0 = undefined; _ = &v41;
    var v42: *UH0 = undefined; _ = &v42;
    var v43: *UH0 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v21 = v0.c3_0;
            v22 = v0.c3_1;
            v23 = v0.c3_2;
            v24 = derivative_equation_proof_candidate_7(v22);
            v25 = derivative_equation_proof_candidate_7(v23);
            return UH0_RegexAlt(v24, v25);
        },
        4 => {
            v27 = v0.c4_0;
            v28 = v0.c4_1;
            v29 = v0.c4_2;
            v30 = v0.c4_3;
            v31 = derivative_equation_proof_candidate_7(v29);
            v32 = derivative_equation_proof_candidate_7(v30);
            v33 = derivative_equation_proof_source_5(v30);
            switch (v28.tag) {
                1 => {
                    return UH0_RegexCat(v31, v33);
                },
                0 => {
                    v34 = UH0_RegexCat(v31, v33);
                    return UH0_RegexAlt(v34, v32);
                },
                else => unreachable,
            }
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            switch (v5.tag) {
                1 => {
                    switch (v6.tag) {
                        1 => {
                            v16 = US4_SymbolSame();
                        },
                        0 => {
                            v16 = US4_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v6.tag) {
                        1 => {
                            v16 = US4_SymbolLess();
                        },
                        0 => {
                            v16 = US4_SymbolSame();
                        },
                        else => unreachable,
                    }
                },
                else => unreachable,
            }
            switch (v16.tag) {
                1 => {
                    v17 = true;
                },
                else => {
                    v17 = false;
                },
            }
            if (v17) {
                return UH0_RegexEpsilon();
            } else {
                return UH0_RegexEmpty();
            }
        },
        0 => {
            v1 = v0.c0_0;
            return UH0_RegexEmpty();
        },
        1 => {
            v3 = v0.c1_0;
            return UH0_RegexEmpty();
        },
        5 => {
            v39 = v0.c5_0;
            v40 = v0.c5_1;
            v41 = derivative_equation_proof_candidate_7(v40);
            v42 = derivative_equation_proof_source_5(v40);
            v43 = UH0_RegexStar(v42);
            return UH0_RegexCat(v41, v43);
        },
        else => unreachable,
    }
}
fn regex_compare_12(p0: *UH0, p1: *UH0) US4 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v53: *UH0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: *UH0 = undefined; _ = &v55;
    var v56: *UH0 = undefined; _ = &v56;
    var v57: US4 = undefined; _ = &v57;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: US4 = undefined; _ = &v36;
    var v32: US0 = undefined; _ = &v32;
    var v10: US0 = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v44: *UH0 = undefined; _ = &v44;
    var v45: *UH0 = undefined; _ = &v45;
    var v46: *UH0 = undefined; _ = &v46;
    var v48: *UH0 = undefined; _ = &v48;
    while (true) {
        switch (v0.tag) {
            3 => {
                v53 = v0.c3_0;
                v54 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v55 = v1.c3_0;
                        v56 = v1.c3_1;
                        v57 = regex_compare_12(v53, v55);
                        switch (v57.tag) {
                            1 => {
                                v0 = v54;
                                v1 = v56;
                                continue;
                            },
                            else => {
                                return v57;
                            },
                        }
                    },
                    else => {
                        return US4_SymbolGreater();
                    },
                }
            },
            4 => {
                v28 = v0.c4_0;
                v29 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v34 = v1.c4_0;
                        v35 = v1.c4_1;
                        v36 = regex_compare_12(v28, v34);
                        switch (v36.tag) {
                            1 => {
                                v0 = v29;
                                v1 = v35;
                                continue;
                            },
                            else => {
                                return v36;
                            },
                        }
                    },
                    2 => {
                        v32 = v1.c2_0;
                        return US4_SymbolGreater();
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            2 => {
                v10 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v13 = v1.c2_0;
                        switch (v10.tag) {
                            1 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US4_SymbolSame();
                                    },
                                    0 => {
                                        return US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US4_SymbolLess();
                                    },
                                    0 => {
                                        return US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US4_SymbolLess();
                    },
                    5 => {
                        v48 = v1.c5_0;
                        v0 = v44;
                        v1 = v48;
                        continue;
                    },
                    else => {
                        return US4_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_11(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: US4 = undefined; _ = &v4;
    var v6: *UH0 = undefined; _ = &v6;
    var v11: US4 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_12(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_11(v0, v3);
                    return UH0_RegexAlt(v2, v6);
                },
                0 => {
                    return UH0_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
        0 => {
            return v0;
        },
        else => {
            v11 = regex_compare_12(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH0_RegexAlt(v1, v0);
                },
                0 => {
                    return UH0_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_10(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_11(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_11(v0, v1);
            },
        }
    }
}
fn regex_equal_14(p0: *UH0, p1: *UH0) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v18: *UH0 = undefined; _ = &v18;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v4: US0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v15: US4 = undefined; _ = &v15;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    while (true) {
        switch (v0.tag) {
            3 => {
                v18 = v0.c3_0;
                v19 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v20 = v1.c3_0;
                        v21 = v1.c3_1;
                        v22 = regex_equal_14(v18, v20);
                        if (v22) {
                            v0 = v19;
                            v1 = v21;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            4 => {
                v26 = v0.c4_0;
                v27 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v28 = v1.c4_0;
                        v29 = v1.c4_1;
                        v30 = regex_equal_14(v26, v28);
                        if (v30) {
                            v0 = v27;
                            v1 = v29;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            2 => {
                v4 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v5 = v1.c2_0;
                        switch (v4.tag) {
                            1 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v15 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v15 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v15.tag) {
                            1 => {
                                return true;
                            },
                            else => {
                                return false;
                            },
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    1 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            5 => {
                v34 = v0.c5_0;
                switch (v1.tag) {
                    5 => {
                        v35 = v1.c5_0;
                        v0 = v34;
                        v1 = v35;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn make_cat_13(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH0 = undefined; _ = &v14;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH0_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH0_RegexEmpty();
                },
                else => {
                    switch (v0.tag) {
                        1 => {
                            return v1;
                        },
                        else => {
                            switch (v1.tag) {
                                1 => {
                                    return v0;
                                },
                                else => {
                                    switch (v0.tag) {
                                        4 => {
                                            v12 = v0.c4_0;
                                            v13 = v0.c4_1;
                                            v14 = make_cat_13(v13, v1);
                                            return UH0_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_14(v4, v5);
                                                    if (v6) {
                                                        return UH0_RegexStar(v4);
                                                    } else {
                                                        return UH0_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH0_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH0_RegexCat(v0, v1);
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            }
        },
    }
}
fn make_star_15(p0: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v3: *UH0 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH0_RegexEpsilon();
        },
        1 => {
            return UH0_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH0_RegexStar(v3);
        },
        else => {
            return UH0_RegexStar(v0);
        },
    }
}
fn normalize_9(p0: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v3: US0 = undefined; _ = &v3;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_9(v5);
            v8 = normalize_9(v6);
            return make_alt_10(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_9(v10);
            v13 = normalize_9(v11);
            return make_cat_13(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH0_RegexChar(v3);
        },
        0 => {
            return UH0_RegexEmpty();
        },
        1 => {
            return UH0_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_9(v15);
            return make_star_15(v16);
        },
        else => unreachable,
    }
}
fn derivative_16(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
    var v31: *UH0 = undefined; _ = &v31;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US4 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_16(v19, v1);
            v22 = derivative_16(v20, v1);
            return make_alt_10(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_1(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_16(v24, v1);
                    return make_cat_13(v31, v25);
                },
                0 => {
                    v27 = derivative_16(v24, v1);
                    v28 = make_cat_13(v27, v25);
                    v29 = derivative_16(v25, v1);
                    return make_alt_10(v28, v29);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                1 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US4_SymbolSame();
                        },
                        0 => {
                            v14 = US4_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US4_SymbolLess();
                        },
                        0 => {
                            v14 = US4_SymbolSame();
                        },
                        else => unreachable,
                    }
                },
                else => unreachable,
            }
            switch (v14.tag) {
                1 => {
                    v15 = true;
                },
                else => {
                    v15 = false;
                },
            }
            if (v15) {
                return UH0_RegexEpsilon();
            } else {
                return UH0_RegexEmpty();
            }
        },
        0 => {
            return UH0_RegexEmpty();
        },
        1 => {
            return UH0_RegexEmpty();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = derivative_16(v35, v1);
            v37 = make_star_15(v35);
            return make_cat_13(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_8(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH0 = normalize_9(v0);
    const v3: *UH0 = derivative_16(v2, v1);
    return normalize_9(v3);
}
fn reference_derivative_17(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
    var v31: *UH0 = undefined; _ = &v31;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US4 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = reference_derivative_17(v19, v1);
            v22 = reference_derivative_17(v20, v1);
            return UH0_RegexAlt(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_1(v24);
            switch (v26.tag) {
                1 => {
                    v31 = reference_derivative_17(v24, v1);
                    return UH0_RegexCat(v31, v25);
                },
                0 => {
                    v27 = reference_derivative_17(v24, v1);
                    v28 = reference_derivative_17(v25, v1);
                    v29 = UH0_RegexCat(v27, v25);
                    return UH0_RegexAlt(v29, v28);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                1 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US4_SymbolSame();
                        },
                        0 => {
                            v14 = US4_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US4_SymbolLess();
                        },
                        0 => {
                            v14 = US4_SymbolSame();
                        },
                        else => unreachable,
                    }
                },
                else => unreachable,
            }
            switch (v14.tag) {
                1 => {
                    v15 = true;
                },
                else => {
                    v15 = false;
                },
            }
            if (v15) {
                return UH0_RegexEpsilon();
            } else {
                return UH0_RegexEmpty();
            }
        },
        0 => {
            return UH0_RegexEmpty();
        },
        1 => {
            return UH0_RegexEmpty();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = reference_derivative_17(v35, v1);
            v37 = UH0_RegexStar(v35);
            return UH0_RegexCat(v36, v37);
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_valid_4(p0: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH0 = undefined; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v11: bool = undefined; _ = &v11;
    var v9: *UH0 = undefined; _ = &v9;
    var v18: bool = undefined; _ = &v18;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH0 = undefined; _ = &v14;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    var v23: US0 = undefined; _ = &v23;
    var v24: *UH1 = undefined; _ = &v24;
    var v25: *UH1 = undefined; _ = &v25;
    var v26: US0 = undefined; _ = &v26;
    var v27: US0 = undefined; _ = &v27;
    var v37: US4 = undefined; _ = &v37;
    var v38: bool = undefined; _ = &v38;
    var v52: bool = undefined; _ = &v52;
    var v39: US0 = undefined; _ = &v39;
    var v40: US0 = undefined; _ = &v40;
    var v50: US4 = undefined; _ = &v50;
    var v54: bool = undefined; _ = &v54;
    var v57: US0 = undefined; _ = &v57;
    var v58: US1 = undefined; _ = &v58;
    var v59: *UH1 = undefined; _ = &v59;
    var v60: *UH1 = undefined; _ = &v60;
    var v61: *UH0 = undefined; _ = &v61;
    var v62: US2 = undefined; _ = &v62;
    var v66: US1 = undefined; _ = &v66;
    var v70: bool = undefined; _ = &v70;
    var v84: bool = undefined; _ = &v84;
    var v71: US0 = undefined; _ = &v71;
    var v72: US0 = undefined; _ = &v72;
    var v82: US4 = undefined; _ = &v82;
    var v98: bool = undefined; _ = &v98;
    var v85: US0 = undefined; _ = &v85;
    var v86: US0 = undefined; _ = &v86;
    var v96: US4 = undefined; _ = &v96;
    var v100: bool = undefined; _ = &v100;
    var v21: US0 = undefined; _ = &v21;
    var v22: US0 = undefined; _ = &v22;
    var v19: US0 = undefined; _ = &v19;
    var v20: US0 = undefined; _ = &v20;
    var v103: US0 = undefined; _ = &v103;
    var v104: *UH1 = undefined; _ = &v104;
    var v105: US0 = undefined; _ = &v105;
    var v106: US0 = undefined; _ = &v106;
    var v116: US4 = undefined; _ = &v116;
    var v117: bool = undefined; _ = &v117;
    while (true) {
        v1 = derivative_equation_proof_source_5(v0);
        v2 = derivative_equation_proof_symbol_6(v0);
        v3 = derivative_equation_proof_candidate_7(v0);
        v4 = canonical_derivative_8(v1, v2);
        v5 = reference_derivative_17(v1, v2);
        v6 = normalize_9(v5);
        v7 = normalize_9(v3);
        v8 = regex_equal_14(v7, v4);
        if (v8) {
            v9 = normalize_9(v3);
            v11 = regex_equal_14(v9, v6);
        } else {
            v11 = false;
        }
        if (v11) {
            v12 = normalize_9(v1);
            v13 = derivative_16(v12, v2);
            v14 = normalize_9(v13);
            v15 = derivative_16(v1, v2);
            v16 = normalize_9(v15);
            v18 = regex_equal_14(v14, v16);
        } else {
            v18 = false;
        }
        if (v18) {
            switch (v0.tag) {
                3 => {
                    v23 = v0.c3_0;
                    v24 = v0.c3_1;
                    v25 = v0.c3_2;
                    v26 = derivative_equation_proof_symbol_6(v0);
                    v27 = derivative_equation_proof_symbol_6(v24);
                    switch (v26.tag) {
                        1 => {
                            switch (v27.tag) {
                                1 => {
                                    v37 = US4_SymbolSame();
                                },
                                0 => {
                                    v37 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v27.tag) {
                                1 => {
                                    v37 = US4_SymbolLess();
                                },
                                0 => {
                                    v37 = US4_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v37.tag) {
                        1 => {
                            v38 = true;
                        },
                        else => {
                            v38 = false;
                        },
                    }
                    if (v38) {
                        v39 = derivative_equation_proof_symbol_6(v0);
                        v40 = derivative_equation_proof_symbol_6(v25);
                        switch (v39.tag) {
                            1 => {
                                switch (v40.tag) {
                                    1 => {
                                        v50 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v50 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v40.tag) {
                                    1 => {
                                        v50 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v50 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v50.tag) {
                            1 => {
                                v52 = true;
                            },
                            else => {
                                v52 = false;
                            },
                        }
                    } else {
                        v52 = false;
                    }
                    if (v52) {
                        v54 = derivative_equation_proof_valid_4(v24);
                    } else {
                        v54 = false;
                    }
                    if (v54) {
                        v0 = v25;
                        continue;
                    } else {
                        return false;
                    }
                },
                4 => {
                    v57 = v0.c4_0;
                    v58 = v0.c4_1;
                    v59 = v0.c4_2;
                    v60 = v0.c4_3;
                    v61 = derivative_equation_proof_source_5(v59);
                    v62 = nullable_1(v61);
                    switch (v62.tag) {
                        1 => {
                            v66 = US1_EquationCatNonNullable();
                        },
                        0 => {
                            v66 = US1_EquationCatNullable();
                        },
                        else => unreachable,
                    }
                    switch (v58.tag) {
                        1 => {
                            switch (v66.tag) {
                                1 => {
                                    v70 = true;
                                },
                                else => {
                                    v70 = false;
                                },
                            }
                        },
                        0 => {
                            switch (v66.tag) {
                                0 => {
                                    v70 = true;
                                },
                                else => {
                                    v70 = false;
                                },
                            }
                        },
                        else => unreachable,
                    }
                    if (v70) {
                        v71 = derivative_equation_proof_symbol_6(v0);
                        v72 = derivative_equation_proof_symbol_6(v59);
                        switch (v71.tag) {
                            1 => {
                                switch (v72.tag) {
                                    1 => {
                                        v82 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v82 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v72.tag) {
                                    1 => {
                                        v82 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v82 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v82.tag) {
                            1 => {
                                v84 = true;
                            },
                            else => {
                                v84 = false;
                            },
                        }
                    } else {
                        v84 = false;
                    }
                    if (v84) {
                        v85 = derivative_equation_proof_symbol_6(v0);
                        v86 = derivative_equation_proof_symbol_6(v60);
                        switch (v85.tag) {
                            1 => {
                                switch (v86.tag) {
                                    1 => {
                                        v96 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v96 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v86.tag) {
                                    1 => {
                                        v96 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v96 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v96.tag) {
                            1 => {
                                v98 = true;
                            },
                            else => {
                                v98 = false;
                            },
                        }
                    } else {
                        v98 = false;
                    }
                    if (v98) {
                        v100 = derivative_equation_proof_valid_4(v59);
                    } else {
                        v100 = false;
                    }
                    if (v100) {
                        v0 = v60;
                        continue;
                    } else {
                        return false;
                    }
                },
                2 => {
                    v21 = v0.c2_0;
                    v22 = v0.c2_1;
                    return true;
                },
                0 => {
                    v19 = v0.c0_0;
                    return true;
                },
                1 => {
                    v20 = v0.c1_0;
                    return true;
                },
                5 => {
                    v103 = v0.c5_0;
                    v104 = v0.c5_1;
                    v105 = derivative_equation_proof_symbol_6(v0);
                    v106 = derivative_equation_proof_symbol_6(v104);
                    switch (v105.tag) {
                        1 => {
                            switch (v106.tag) {
                                1 => {
                                    v116 = US4_SymbolSame();
                                },
                                0 => {
                                    v116 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v106.tag) {
                                1 => {
                                    v116 = US4_SymbolLess();
                                },
                                0 => {
                                    v116 = US4_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v116.tag) {
                        1 => {
                            v117 = true;
                        },
                        else => {
                            v117 = false;
                        },
                    }
                    if (v117) {
                        v0 = v104;
                        continue;
                    } else {
                        return false;
                    }
                },
                else => unreachable,
            }
        } else {
            return false;
        }
    }
}
fn derivative_equation_proof_source_19(p0: *UH3) *UH2 {
    var v0: *UH3 = p0; _ = &v0;
    var v8: US3 = undefined; _ = &v8;
    var v9: *UH3 = undefined; _ = &v9;
    var v10: *UH3 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v14: US3 = undefined; _ = &v14;
    var v15: US1 = undefined; _ = &v15;
    var v16: *UH3 = undefined; _ = &v16;
    var v17: *UH3 = undefined; _ = &v17;
    var v18: *UH2 = undefined; _ = &v18;
    var v19: *UH2 = undefined; _ = &v19;
    var v5: US3 = undefined; _ = &v5;
    var v6: US3 = undefined; _ = &v6;
    var v1: US3 = undefined; _ = &v1;
    var v3: US3 = undefined; _ = &v3;
    var v21: US3 = undefined; _ = &v21;
    var v22: *UH3 = undefined; _ = &v22;
    var v23: *UH2 = undefined; _ = &v23;
    switch (v0.tag) {
        3 => {
            v8 = v0.c3_0;
            v9 = v0.c3_1;
            v10 = v0.c3_2;
            v11 = derivative_equation_proof_source_19(v9);
            v12 = derivative_equation_proof_source_19(v10);
            return UH2_RegexAlt(v11, v12);
        },
        4 => {
            v14 = v0.c4_0;
            v15 = v0.c4_1;
            v16 = v0.c4_2;
            v17 = v0.c4_3;
            v18 = derivative_equation_proof_source_19(v16);
            v19 = derivative_equation_proof_source_19(v17);
            return UH2_RegexCat(v18, v19);
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            return UH2_RegexChar(v5);
        },
        0 => {
            v1 = v0.c0_0;
            return UH2_RegexEmpty();
        },
        1 => {
            v3 = v0.c1_0;
            return UH2_RegexEpsilon();
        },
        5 => {
            v21 = v0.c5_0;
            v22 = v0.c5_1;
            v23 = derivative_equation_proof_source_19(v22);
            return UH2_RegexStar(v23);
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_symbol_20(p0: *UH3) US3 {
    var v0: *UH3 = p0; _ = &v0;
    var v5: US3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v9: US1 = undefined; _ = &v9;
    var v10: *UH3 = undefined; _ = &v10;
    var v11: *UH3 = undefined; _ = &v11;
    var v3: US3 = undefined; _ = &v3;
    var v4: US3 = undefined; _ = &v4;
    var v1: US3 = undefined; _ = &v1;
    var v2: US3 = undefined; _ = &v2;
    var v12: US3 = undefined; _ = &v12;
    var v13: *UH3 = undefined; _ = &v13;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = v0.c3_2;
            return v5;
        },
        4 => {
            v8 = v0.c4_0;
            v9 = v0.c4_1;
            v10 = v0.c4_2;
            v11 = v0.c4_3;
            return v8;
        },
        2 => {
            v3 = v0.c2_0;
            v4 = v0.c2_1;
            return v4;
        },
        0 => {
            v1 = v0.c0_0;
            return v1;
        },
        1 => {
            v2 = v0.c1_0;
            return v2;
        },
        5 => {
            v12 = v0.c5_0;
            v13 = v0.c5_1;
            return v12;
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_candidate_21(p0: *UH3) *UH2 {
    var v0: *UH3 = p0; _ = &v0;
    var v27: US3 = undefined; _ = &v27;
    var v28: *UH3 = undefined; _ = &v28;
    var v29: *UH3 = undefined; _ = &v29;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v33: US3 = undefined; _ = &v33;
    var v34: US1 = undefined; _ = &v34;
    var v35: *UH3 = undefined; _ = &v35;
    var v36: *UH3 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    var v38: *UH2 = undefined; _ = &v38;
    var v39: *UH2 = undefined; _ = &v39;
    var v40: *UH2 = undefined; _ = &v40;
    var v5: US3 = undefined; _ = &v5;
    var v6: US3 = undefined; _ = &v6;
    var v22: US4 = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var v1: US3 = undefined; _ = &v1;
    var v3: US3 = undefined; _ = &v3;
    var v45: US3 = undefined; _ = &v45;
    var v46: *UH3 = undefined; _ = &v46;
    var v47: *UH2 = undefined; _ = &v47;
    var v48: *UH2 = undefined; _ = &v48;
    var v49: *UH2 = undefined; _ = &v49;
    switch (v0.tag) {
        3 => {
            v27 = v0.c3_0;
            v28 = v0.c3_1;
            v29 = v0.c3_2;
            v30 = derivative_equation_proof_candidate_21(v28);
            v31 = derivative_equation_proof_candidate_21(v29);
            return UH2_RegexAlt(v30, v31);
        },
        4 => {
            v33 = v0.c4_0;
            v34 = v0.c4_1;
            v35 = v0.c4_2;
            v36 = v0.c4_3;
            v37 = derivative_equation_proof_candidate_21(v35);
            v38 = derivative_equation_proof_candidate_21(v36);
            v39 = derivative_equation_proof_source_19(v36);
            switch (v34.tag) {
                1 => {
                    return UH2_RegexCat(v37, v39);
                },
                0 => {
                    v40 = UH2_RegexCat(v37, v39);
                    return UH2_RegexAlt(v40, v38);
                },
                else => unreachable,
            }
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            switch (v5.tag) {
                0 => {
                    switch (v6.tag) {
                        0 => {
                            v22 = US4_SymbolSame();
                        },
                        else => {
                            v22 = US4_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v6.tag) {
                        0 => {
                            v22 = US4_SymbolGreater();
                        },
                        else => {
                            switch (v5.tag) {
                                1 => {
                                    switch (v6.tag) {
                                        1 => {
                                            v22 = US4_SymbolSame();
                                        },
                                        2 => {
                                            v22 = US4_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v6.tag) {
                                        1 => {
                                            v22 = US4_SymbolGreater();
                                        },
                                        2 => {
                                            v22 = US4_SymbolSame();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
            switch (v22.tag) {
                1 => {
                    v23 = true;
                },
                else => {
                    v23 = false;
                },
            }
            if (v23) {
                return UH2_RegexEpsilon();
            } else {
                return UH2_RegexEmpty();
            }
        },
        0 => {
            v1 = v0.c0_0;
            return UH2_RegexEmpty();
        },
        1 => {
            v3 = v0.c1_0;
            return UH2_RegexEmpty();
        },
        5 => {
            v45 = v0.c5_0;
            v46 = v0.c5_1;
            v47 = derivative_equation_proof_candidate_21(v46);
            v48 = derivative_equation_proof_source_19(v46);
            v49 = UH2_RegexStar(v48);
            return UH2_RegexCat(v47, v49);
        },
        else => unreachable,
    }
}
fn regex_compare_26(p0: *UH2, p1: *UH2) US4 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v59: *UH2 = undefined; _ = &v59;
    var v60: *UH2 = undefined; _ = &v60;
    var v61: *UH2 = undefined; _ = &v61;
    var v62: *UH2 = undefined; _ = &v62;
    var v63: US4 = undefined; _ = &v63;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: US4 = undefined; _ = &v42;
    var v38: US3 = undefined; _ = &v38;
    var v10: US3 = undefined; _ = &v10;
    var v13: US3 = undefined; _ = &v13;
    var v50: *UH2 = undefined; _ = &v50;
    var v51: *UH2 = undefined; _ = &v51;
    var v52: *UH2 = undefined; _ = &v52;
    var v54: *UH2 = undefined; _ = &v54;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_26(v59, v61);
                        switch (v63.tag) {
                            1 => {
                                v0 = v60;
                                v1 = v62;
                                continue;
                            },
                            else => {
                                return v63;
                            },
                        }
                    },
                    else => {
                        return US4_SymbolGreater();
                    },
                }
            },
            4 => {
                v34 = v0.c4_0;
                v35 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v40 = v1.c4_0;
                        v41 = v1.c4_1;
                        v42 = regex_compare_26(v34, v40);
                        switch (v42.tag) {
                            1 => {
                                v0 = v35;
                                v1 = v41;
                                continue;
                            },
                            else => {
                                return v42;
                            },
                        }
                    },
                    2 => {
                        v38 = v1.c2_0;
                        return US4_SymbolGreater();
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            2 => {
                v10 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v13 = v1.c2_0;
                        switch (v10.tag) {
                            0 => {
                                switch (v13.tag) {
                                    0 => {
                                        return US4_SymbolSame();
                                    },
                                    else => {
                                        return US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        return US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        return US4_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US4_SymbolLess();
                    },
                    5 => {
                        v54 = v1.c5_0;
                        v0 = v50;
                        v1 = v54;
                        continue;
                    },
                    else => {
                        return US4_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_25(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: US4 = undefined; _ = &v4;
    var v6: *UH2 = undefined; _ = &v6;
    var v11: US4 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_26(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_25(v0, v3);
                    return UH2_RegexAlt(v2, v6);
                },
                0 => {
                    return UH2_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
        0 => {
            return v0;
        },
        else => {
            v11 = regex_compare_26(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH2_RegexAlt(v1, v0);
                },
                0 => {
                    return UH2_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_24(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_25(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_25(v0, v1);
            },
        }
    }
}
fn regex_equal_28(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US3 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v21: US4 = undefined; _ = &v21;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: *UH2 = undefined; _ = &v41;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_28(v24, v26);
                        if (v28) {
                            v0 = v25;
                            v1 = v27;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            4 => {
                v32 = v0.c4_0;
                v33 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v34 = v1.c4_0;
                        v35 = v1.c4_1;
                        v36 = regex_equal_28(v32, v34);
                        if (v36) {
                            v0 = v33;
                            v1 = v35;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            2 => {
                v4 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v5 = v1.c2_0;
                        switch (v4.tag) {
                            0 => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US4_SymbolSame();
                                    },
                                    else => {
                                        v21 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v21 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v21 = US4_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v21.tag) {
                            1 => {
                                return true;
                            },
                            else => {
                                return false;
                            },
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    1 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            5 => {
                v40 = v0.c5_0;
                switch (v1.tag) {
                    5 => {
                        v41 = v1.c5_0;
                        v0 = v40;
                        v1 = v41;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn make_cat_27(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH2_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH2_RegexEmpty();
                },
                else => {
                    switch (v0.tag) {
                        1 => {
                            return v1;
                        },
                        else => {
                            switch (v1.tag) {
                                1 => {
                                    return v0;
                                },
                                else => {
                                    switch (v0.tag) {
                                        4 => {
                                            v12 = v0.c4_0;
                                            v13 = v0.c4_1;
                                            v14 = make_cat_27(v13, v1);
                                            return UH2_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_28(v4, v5);
                                                    if (v6) {
                                                        return UH2_RegexStar(v4);
                                                    } else {
                                                        return UH2_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH2_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH2_RegexCat(v0, v1);
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            }
        },
    }
}
fn make_star_29(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v3: *UH2 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH2_RegexEpsilon();
        },
        1 => {
            return UH2_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH2_RegexStar(v3);
        },
        else => {
            return UH2_RegexStar(v0);
        },
    }
}
fn normalize_23(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v3: US3 = undefined; _ = &v3;
    var v15: *UH2 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_23(v5);
            v8 = normalize_23(v6);
            return make_alt_24(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_23(v10);
            v13 = normalize_23(v11);
            return make_cat_27(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH2_RegexChar(v3);
        },
        0 => {
            return UH2_RegexEmpty();
        },
        1 => {
            return UH2_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_23(v15);
            return make_star_29(v16);
        },
        else => unreachable,
    }
}
fn derivative_30(p0: *UH2, p1: US3) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v32: US2 = undefined; _ = &v32;
    var v37: *UH2 = undefined; _ = &v37;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v4: US3 = undefined; _ = &v4;
    var v20: US4 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: *UH2 = undefined; _ = &v42;
    var v43: *UH2 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_30(v25, v1);
            v28 = derivative_30(v26, v1);
            return make_alt_24(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_3(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_30(v30, v1);
                    return make_cat_27(v37, v31);
                },
                0 => {
                    v33 = derivative_30(v30, v1);
                    v34 = make_cat_27(v33, v31);
                    v35 = derivative_30(v31, v1);
                    return make_alt_24(v34, v35);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                0 => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US4_SymbolSame();
                        },
                        else => {
                            v20 = US4_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US4_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US4_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US4_SymbolSame();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
            switch (v20.tag) {
                1 => {
                    v21 = true;
                },
                else => {
                    v21 = false;
                },
            }
            if (v21) {
                return UH2_RegexEpsilon();
            } else {
                return UH2_RegexEmpty();
            }
        },
        0 => {
            return UH2_RegexEmpty();
        },
        1 => {
            return UH2_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_30(v41, v1);
            v43 = make_star_29(v41);
            return make_cat_27(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_22(p0: *UH2, p1: US3) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    const v2: *UH2 = normalize_23(v0);
    const v3: *UH2 = derivative_30(v2, v1);
    return normalize_23(v3);
}
fn reference_derivative_31(p0: *UH2, p1: US3) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v32: US2 = undefined; _ = &v32;
    var v37: *UH2 = undefined; _ = &v37;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v4: US3 = undefined; _ = &v4;
    var v20: US4 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: *UH2 = undefined; _ = &v42;
    var v43: *UH2 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = reference_derivative_31(v25, v1);
            v28 = reference_derivative_31(v26, v1);
            return UH2_RegexAlt(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_3(v30);
            switch (v32.tag) {
                1 => {
                    v37 = reference_derivative_31(v30, v1);
                    return UH2_RegexCat(v37, v31);
                },
                0 => {
                    v33 = reference_derivative_31(v30, v1);
                    v34 = reference_derivative_31(v31, v1);
                    v35 = UH2_RegexCat(v33, v31);
                    return UH2_RegexAlt(v35, v34);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                0 => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US4_SymbolSame();
                        },
                        else => {
                            v20 = US4_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US4_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US4_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US4_SymbolSame();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
            switch (v20.tag) {
                1 => {
                    v21 = true;
                },
                else => {
                    v21 = false;
                },
            }
            if (v21) {
                return UH2_RegexEpsilon();
            } else {
                return UH2_RegexEmpty();
            }
        },
        0 => {
            return UH2_RegexEmpty();
        },
        1 => {
            return UH2_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = reference_derivative_31(v41, v1);
            v43 = UH2_RegexStar(v41);
            return UH2_RegexCat(v42, v43);
        },
        else => unreachable,
    }
}
fn derivative_equation_proof_valid_18(p0: *UH3) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v11: bool = undefined; _ = &v11;
    var v9: *UH2 = undefined; _ = &v9;
    var v18: bool = undefined; _ = &v18;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v15: *UH2 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    var v23: US3 = undefined; _ = &v23;
    var v24: *UH3 = undefined; _ = &v24;
    var v25: *UH3 = undefined; _ = &v25;
    var v26: US3 = undefined; _ = &v26;
    var v27: US3 = undefined; _ = &v27;
    var v43: US4 = undefined; _ = &v43;
    var v44: bool = undefined; _ = &v44;
    var v64: bool = undefined; _ = &v64;
    var v45: US3 = undefined; _ = &v45;
    var v46: US3 = undefined; _ = &v46;
    var v62: US4 = undefined; _ = &v62;
    var v66: bool = undefined; _ = &v66;
    var v69: US3 = undefined; _ = &v69;
    var v70: US1 = undefined; _ = &v70;
    var v71: *UH3 = undefined; _ = &v71;
    var v72: *UH3 = undefined; _ = &v72;
    var v73: *UH2 = undefined; _ = &v73;
    var v74: US2 = undefined; _ = &v74;
    var v78: US1 = undefined; _ = &v78;
    var v82: bool = undefined; _ = &v82;
    var v102: bool = undefined; _ = &v102;
    var v83: US3 = undefined; _ = &v83;
    var v84: US3 = undefined; _ = &v84;
    var v100: US4 = undefined; _ = &v100;
    var v122: bool = undefined; _ = &v122;
    var v103: US3 = undefined; _ = &v103;
    var v104: US3 = undefined; _ = &v104;
    var v120: US4 = undefined; _ = &v120;
    var v124: bool = undefined; _ = &v124;
    var v21: US3 = undefined; _ = &v21;
    var v22: US3 = undefined; _ = &v22;
    var v19: US3 = undefined; _ = &v19;
    var v20: US3 = undefined; _ = &v20;
    var v127: US3 = undefined; _ = &v127;
    var v128: *UH3 = undefined; _ = &v128;
    var v129: US3 = undefined; _ = &v129;
    var v130: US3 = undefined; _ = &v130;
    var v146: US4 = undefined; _ = &v146;
    var v147: bool = undefined; _ = &v147;
    while (true) {
        v1 = derivative_equation_proof_source_19(v0);
        v2 = derivative_equation_proof_symbol_20(v0);
        v3 = derivative_equation_proof_candidate_21(v0);
        v4 = canonical_derivative_22(v1, v2);
        v5 = reference_derivative_31(v1, v2);
        v6 = normalize_23(v5);
        v7 = normalize_23(v3);
        v8 = regex_equal_28(v7, v4);
        if (v8) {
            v9 = normalize_23(v3);
            v11 = regex_equal_28(v9, v6);
        } else {
            v11 = false;
        }
        if (v11) {
            v12 = normalize_23(v1);
            v13 = derivative_30(v12, v2);
            v14 = normalize_23(v13);
            v15 = derivative_30(v1, v2);
            v16 = normalize_23(v15);
            v18 = regex_equal_28(v14, v16);
        } else {
            v18 = false;
        }
        if (v18) {
            switch (v0.tag) {
                3 => {
                    v23 = v0.c3_0;
                    v24 = v0.c3_1;
                    v25 = v0.c3_2;
                    v26 = derivative_equation_proof_symbol_20(v0);
                    v27 = derivative_equation_proof_symbol_20(v24);
                    switch (v26.tag) {
                        0 => {
                            switch (v27.tag) {
                                0 => {
                                    v43 = US4_SymbolSame();
                                },
                                else => {
                                    v43 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v27.tag) {
                                0 => {
                                    v43 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v26.tag) {
                                        1 => {
                                            switch (v27.tag) {
                                                1 => {
                                                    v43 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v43 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v27.tag) {
                                                1 => {
                                                    v43 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v43 = US4_SymbolSame();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        else => unreachable,
                                    }
                                },
                            }
                        },
                    }
                    switch (v43.tag) {
                        1 => {
                            v44 = true;
                        },
                        else => {
                            v44 = false;
                        },
                    }
                    if (v44) {
                        v45 = derivative_equation_proof_symbol_20(v0);
                        v46 = derivative_equation_proof_symbol_20(v25);
                        switch (v45.tag) {
                            0 => {
                                switch (v46.tag) {
                                    0 => {
                                        v62 = US4_SymbolSame();
                                    },
                                    else => {
                                        v62 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v46.tag) {
                                    0 => {
                                        v62 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v45.tag) {
                                            1 => {
                                                switch (v46.tag) {
                                                    1 => {
                                                        v62 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v62 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v46.tag) {
                                                    1 => {
                                                        v62 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v62 = US4_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v62.tag) {
                            1 => {
                                v64 = true;
                            },
                            else => {
                                v64 = false;
                            },
                        }
                    } else {
                        v64 = false;
                    }
                    if (v64) {
                        v66 = derivative_equation_proof_valid_18(v24);
                    } else {
                        v66 = false;
                    }
                    if (v66) {
                        v0 = v25;
                        continue;
                    } else {
                        return false;
                    }
                },
                4 => {
                    v69 = v0.c4_0;
                    v70 = v0.c4_1;
                    v71 = v0.c4_2;
                    v72 = v0.c4_3;
                    v73 = derivative_equation_proof_source_19(v71);
                    v74 = nullable_3(v73);
                    switch (v74.tag) {
                        1 => {
                            v78 = US1_EquationCatNonNullable();
                        },
                        0 => {
                            v78 = US1_EquationCatNullable();
                        },
                        else => unreachable,
                    }
                    switch (v70.tag) {
                        1 => {
                            switch (v78.tag) {
                                1 => {
                                    v82 = true;
                                },
                                else => {
                                    v82 = false;
                                },
                            }
                        },
                        0 => {
                            switch (v78.tag) {
                                0 => {
                                    v82 = true;
                                },
                                else => {
                                    v82 = false;
                                },
                            }
                        },
                        else => unreachable,
                    }
                    if (v82) {
                        v83 = derivative_equation_proof_symbol_20(v0);
                        v84 = derivative_equation_proof_symbol_20(v71);
                        switch (v83.tag) {
                            0 => {
                                switch (v84.tag) {
                                    0 => {
                                        v100 = US4_SymbolSame();
                                    },
                                    else => {
                                        v100 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v84.tag) {
                                    0 => {
                                        v100 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v83.tag) {
                                            1 => {
                                                switch (v84.tag) {
                                                    1 => {
                                                        v100 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v100 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v84.tag) {
                                                    1 => {
                                                        v100 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v100 = US4_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v100.tag) {
                            1 => {
                                v102 = true;
                            },
                            else => {
                                v102 = false;
                            },
                        }
                    } else {
                        v102 = false;
                    }
                    if (v102) {
                        v103 = derivative_equation_proof_symbol_20(v0);
                        v104 = derivative_equation_proof_symbol_20(v72);
                        switch (v103.tag) {
                            0 => {
                                switch (v104.tag) {
                                    0 => {
                                        v120 = US4_SymbolSame();
                                    },
                                    else => {
                                        v120 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v104.tag) {
                                    0 => {
                                        v120 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v103.tag) {
                                            1 => {
                                                switch (v104.tag) {
                                                    1 => {
                                                        v120 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v120 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v104.tag) {
                                                    1 => {
                                                        v120 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v120 = US4_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v120.tag) {
                            1 => {
                                v122 = true;
                            },
                            else => {
                                v122 = false;
                            },
                        }
                    } else {
                        v122 = false;
                    }
                    if (v122) {
                        v124 = derivative_equation_proof_valid_18(v71);
                    } else {
                        v124 = false;
                    }
                    if (v124) {
                        v0 = v72;
                        continue;
                    } else {
                        return false;
                    }
                },
                2 => {
                    v21 = v0.c2_0;
                    v22 = v0.c2_1;
                    return true;
                },
                0 => {
                    v19 = v0.c0_0;
                    return true;
                },
                1 => {
                    v20 = v0.c1_0;
                    return true;
                },
                5 => {
                    v127 = v0.c5_0;
                    v128 = v0.c5_1;
                    v129 = derivative_equation_proof_symbol_20(v0);
                    v130 = derivative_equation_proof_symbol_20(v128);
                    switch (v129.tag) {
                        0 => {
                            switch (v130.tag) {
                                0 => {
                                    v146 = US4_SymbolSame();
                                },
                                else => {
                                    v146 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v130.tag) {
                                0 => {
                                    v146 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v129.tag) {
                                        1 => {
                                            switch (v130.tag) {
                                                1 => {
                                                    v146 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v146 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v130.tag) {
                                                1 => {
                                                    v146 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v146 = US4_SymbolSame();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        else => unreachable,
                                    }
                                },
                            }
                        },
                    }
                    switch (v146.tag) {
                        1 => {
                            v147 = true;
                        },
                        else => {
                            v147 = false;
                        },
                    }
                    if (v147) {
                        v0 = v128;
                        continue;
                    } else {
                        return false;
                    }
                },
                else => unreachable,
            }
        } else {
            return false;
        }
    }
}
fn UH4_SymbolListNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_SymbolListCons(a0: US0, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH6_InputEmpty() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 0 };
    };
    return &shared.value;
}
fn UH6_InputCons(a0: US0, a1: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH5_InputListNil() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_InputListCons(a0: *UH6, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_singletons_from_symbols_32(p0: *UH4) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH6 = undefined; _ = &v5;
    var v6: *UH6 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_singletons_from_symbols_32(v3);
            v5 = UH6_InputEmpty();
            v6 = UH6_InputCons(v2, v5);
            return UH5_InputListCons(v6, v4);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_list_append_34(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_34(v3, v1);
            return UH5_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn input_prepend_symbol_to_corpus_35(p0: US0, p1: *UH5) *UH5 {
    var v0: US0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH6 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = input_prepend_symbol_to_corpus_35(v0, v4);
            v6 = UH6_InputCons(v0, v3);
            return UH5_InputListCons(v6, v5);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbols_to_corpus_33(p0: *UH4, p1: *UH5) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = input_prepend_symbol_to_corpus_35(v3, v1);
            v6 = input_prepend_symbols_to_corpus_33(v4, v1);
            return input_list_append_34(v5, v6);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn UH7_SymbolListNil() *UH7 {
    const shared = struct {
        var value: UH7 = UH7{ .tag = 0 };
    };
    return &shared.value;
}
fn UH7_SymbolListCons(a0: US3, a1: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH9_InputEmpty() *UH9 {
    const shared = struct {
        var value: UH9 = UH9{ .tag = 0 };
    };
    return &shared.value;
}
fn UH9_InputCons(a0: US3, a1: *UH9) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH8_InputListNil() *UH8 {
    const shared = struct {
        var value: UH8 = UH8{ .tag = 0 };
    };
    return &shared.value;
}
fn UH8_InputListCons(a0: *UH9, a1: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_singletons_from_symbols_36(p0: *UH7) *UH8 {
    var v0: *UH7 = p0; _ = &v0;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_singletons_from_symbols_36(v3);
            v5 = UH9_InputEmpty();
            v6 = UH9_InputCons(v2, v5);
            return UH8_InputListCons(v6, v4);
        },
        0 => {
            return UH8_InputListNil();
        },
        else => unreachable,
    }
}
fn input_list_append_38(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_38(v3, v1);
            return UH8_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn input_prepend_symbol_to_corpus_39(p0: US3, p1: *UH8) *UH8 {
    var v0: US3 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = input_prepend_symbol_to_corpus_39(v0, v4);
            v6 = UH9_InputCons(v0, v3);
            return UH8_InputListCons(v6, v5);
        },
        0 => {
            return UH8_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbols_to_corpus_37(p0: *UH7, p1: *UH8) *UH8 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = input_prepend_symbol_to_corpus_39(v3, v1);
            v6 = input_prepend_symbols_to_corpus_37(v4, v1);
            return input_list_append_38(v5, v6);
        },
        0 => {
            return UH8_InputListNil();
        },
        else => unreachable,
    }
}
fn consume_right_41(p0: *UH0, p1: *UH5) *UH5 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_40(v0, v3);
            v6 = consume_right_41(v0, v4);
            return input_list_append_34(v5, v6);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_45(p0: *UH6, p1: *UH6) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH6 = undefined; _ = &v6;
    var v16: US4 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v5 = v1.c1_0;
                        v6 = v1.c1_1;
                        switch (v3.tag) {
                            1 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v16 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v16 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v16.tag) {
                            1 => {
                                v17 = true;
                            },
                            else => {
                                v17 = false;
                            },
                        }
                        if (v17) {
                            v0 = v4;
                            v1 = v6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn input_list_contains_44(p0: *UH6, p1: *UH5) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_45(v0, v2);
                if (v4) {
                    return true;
                } else {
                    v1 = v3;
                    continue;
                }
            },
            0 => {
                return false;
            },
            else => unreachable,
        }
    }
}
fn input_list_enqueue_new_43(p0: *UH5, p1: *UH5, p2: *UH5) Tuple0 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_44(v3, v1);
                if (v5) {
                    v0 = v4;
                    continue;
                } else {
                    v8 = UH5_InputListCons(v3, v1);
                    v9 = UH5_InputListCons(v3, v2);
                    v0 = v4;
                    v1 = v8;
                    v2 = v9;
                    continue;
                }
            },
            0 => {
                return Tuple0{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_42(p0: *UH0, p1: *UH5, p2: *UH5) *UH5 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var tmp5: Tuple0 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_40(v0, v3);
                tmp5 = input_list_enqueue_new_43(v5, v2, v4);
                v6 = tmp5.f0;
                v7 = tmp5.f1;
                v1 = v7;
                v2 = v6;
                continue;
            },
            0 => {
                return v2;
            },
            else => unreachable,
        }
    }
}
fn language_remainders_40(p0: *UH0, p1: *UH6) *UH5 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH5 = undefined; _ = &v28;
    var v29: *UH5 = undefined; _ = &v29;
    var v31: *UH0 = undefined; _ = &v31;
    var v32: *UH0 = undefined; _ = &v32;
    var v33: *UH5 = undefined; _ = &v33;
    var v5: US0 = undefined; _ = &v5;
    var v7: US0 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v18: US4 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: *UH5 = undefined; _ = &v20;
    var v3: *UH5 = undefined; _ = &v3;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH5 = undefined; _ = &v36;
    var v37: *UH5 = undefined; _ = &v37;
    var v38: *UH5 = undefined; _ = &v38;
    var v39: *UH5 = undefined; _ = &v39;
    switch (v0.tag) {
        3 => {
            v26 = v0.c3_0;
            v27 = v0.c3_1;
            v28 = language_remainders_40(v26, v1);
            v29 = language_remainders_40(v27, v1);
            return input_list_append_34(v28, v29);
        },
        4 => {
            v31 = v0.c4_0;
            v32 = v0.c4_1;
            v33 = language_remainders_40(v31, v1);
            return consume_right_41(v32, v33);
        },
        2 => {
            v5 = v0.c2_0;
            switch (v1.tag) {
                1 => {
                    v7 = v1.c1_0;
                    v8 = v1.c1_1;
                    switch (v5.tag) {
                        1 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US4_SymbolSame();
                                },
                                0 => {
                                    v18 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US4_SymbolLess();
                                },
                                0 => {
                                    v18 = US4_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v18.tag) {
                        1 => {
                            v19 = true;
                        },
                        else => {
                            v19 = false;
                        },
                    }
                    if (v19) {
                        v20 = UH5_InputListNil();
                        return UH5_InputListCons(v8, v20);
                    } else {
                        return UH5_InputListNil();
                    }
                },
                0 => {
                    return UH5_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH5_InputListNil();
        },
        1 => {
            v3 = UH5_InputListNil();
            return UH5_InputListCons(v1, v3);
        },
        5 => {
            v35 = v0.c5_0;
            v36 = UH5_InputListNil();
            v37 = UH5_InputListCons(v1, v36);
            v38 = UH5_InputListNil();
            v39 = UH5_InputListCons(v1, v38);
            return closure_42(v35, v37, v39);
        },
        else => unreachable,
    }
}
fn input_list_remove_46(p0: *UH6, p1: *UH5) *UH5 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH5 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_45(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_46(v0, v4);
                    return UH5_InputListCons(v3, v7);
                }
            },
            0 => {
                return UH5_InputListNil();
            },
            else => unreachable,
        }
    }
}
fn input_list_subset_47(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_44(v2, v1);
                if (v4) {
                    v0 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn closure0(ctx: *anyopaque, p2: *UH6) bool {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: bool = env.v0; _ = &v0;
    var v1: *UH0 = env.v1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v22: bool = undefined; _ = &v22;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: US0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v9: *UH0 = undefined; _ = &v9;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: US0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: US0 = undefined; _ = &v14;
    var v15: *UH6 = undefined; _ = &v15;
    var v16: *UH5 = undefined; _ = &v16;
    var v17: *UH5 = undefined; _ = &v17;
    var v18: *UH5 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    if (v0) {
        v3 = US0_BitZero();
        v4 = UH6_InputCons(v3, v2);
        v5 = US0_BitZero();
        v6 = UH0_RegexChar(v5);
        v7 = US0_BitOne();
        v8 = UH0_RegexChar(v7);
        v9 = UH0_RegexAlt(v6, v8);
        v10 = UH0_RegexStar(v9);
        v11 = US0_BitZero();
        v12 = UH0_RegexChar(v11);
        v13 = UH0_RegexCat(v10, v12);
        v14 = US0_BitZero();
        v15 = UH6_InputCons(v14, v2);
        v16 = language_remainders_40(v13, v15);
        v17 = input_list_remove_46(v4, v16);
        v18 = language_remainders_40(v1, v2);
        v19 = input_list_subset_47(v17, v18);
        if (v19) {
            v22 = input_list_subset_47(v18, v17);
        } else {
            v22 = false;
        }
    } else {
        v22 = false;
    }
    return v22;
}
fn closureCreate0(p0: bool, p1: *UH0) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, .v1 = p1, }), .call = &closure0 };
}
fn derivative_universal_remainder_family_suffixes_48(p0: Fun0, p1: *UH5) bool {
    var v0: Fun0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = v0.call(v0.ctx, v2);
                if (v4) {
                    v1 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn consume_right_50(p0: *UH2, p1: *UH8) *UH8 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_49(v0, v3);
            v6 = consume_right_50(v0, v4);
            return input_list_append_38(v5, v6);
        },
        0 => {
            return UH8_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_54(p0: *UH9, p1: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    var v22: US4 = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v5 = v1.c1_0;
                        v6 = v1.c1_1;
                        switch (v3.tag) {
                            0 => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US4_SymbolSame();
                                    },
                                    else => {
                                        v22 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v3.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v22 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v22 = US4_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v22.tag) {
                            1 => {
                                v23 = true;
                            },
                            else => {
                                v23 = false;
                            },
                        }
                        if (v23) {
                            v0 = v4;
                            v1 = v6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn input_list_contains_53(p0: *UH9, p1: *UH8) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_54(v0, v2);
                if (v4) {
                    return true;
                } else {
                    v1 = v3;
                    continue;
                }
            },
            0 => {
                return false;
            },
            else => unreachable,
        }
    }
}
fn input_list_enqueue_new_52(p0: *UH8, p1: *UH8, p2: *UH8) Tuple1 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = p2; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH8 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_53(v3, v1);
                if (v5) {
                    v0 = v4;
                    continue;
                } else {
                    v8 = UH8_InputListCons(v3, v1);
                    v9 = UH8_InputListCons(v3, v2);
                    v0 = v4;
                    v1 = v8;
                    v2 = v9;
                    continue;
                }
            },
            0 => {
                return Tuple1{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_51(p0: *UH2, p1: *UH8, p2: *UH8) *UH8 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = p2; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var tmp5: Tuple1 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_49(v0, v3);
                tmp5 = input_list_enqueue_new_52(v5, v2, v4);
                v6 = tmp5.f0;
                v7 = tmp5.f1;
                v1 = v7;
                v2 = v6;
                continue;
            },
            0 => {
                return v2;
            },
            else => unreachable,
        }
    }
}
fn language_remainders_49(p0: *UH2, p1: *UH9) *UH8 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v37: *UH2 = undefined; _ = &v37;
    var v38: *UH2 = undefined; _ = &v38;
    var v39: *UH8 = undefined; _ = &v39;
    var v5: US3 = undefined; _ = &v5;
    var v7: US3 = undefined; _ = &v7;
    var v8: *UH9 = undefined; _ = &v8;
    var v24: US4 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: *UH8 = undefined; _ = &v26;
    var v3: *UH8 = undefined; _ = &v3;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: *UH8 = undefined; _ = &v42;
    var v43: *UH8 = undefined; _ = &v43;
    var v44: *UH8 = undefined; _ = &v44;
    var v45: *UH8 = undefined; _ = &v45;
    switch (v0.tag) {
        3 => {
            v32 = v0.c3_0;
            v33 = v0.c3_1;
            v34 = language_remainders_49(v32, v1);
            v35 = language_remainders_49(v33, v1);
            return input_list_append_38(v34, v35);
        },
        4 => {
            v37 = v0.c4_0;
            v38 = v0.c4_1;
            v39 = language_remainders_49(v37, v1);
            return consume_right_50(v38, v39);
        },
        2 => {
            v5 = v0.c2_0;
            switch (v1.tag) {
                1 => {
                    v7 = v1.c1_0;
                    v8 = v1.c1_1;
                    switch (v5.tag) {
                        0 => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US4_SymbolSame();
                                },
                                else => {
                                    v24 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v5.tag) {
                                        1 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US4_SymbolSame();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        else => unreachable,
                                    }
                                },
                            }
                        },
                    }
                    switch (v24.tag) {
                        1 => {
                            v25 = true;
                        },
                        else => {
                            v25 = false;
                        },
                    }
                    if (v25) {
                        v26 = UH8_InputListNil();
                        return UH8_InputListCons(v8, v26);
                    } else {
                        return UH8_InputListNil();
                    }
                },
                0 => {
                    return UH8_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH8_InputListNil();
        },
        1 => {
            v3 = UH8_InputListNil();
            return UH8_InputListCons(v1, v3);
        },
        5 => {
            v41 = v0.c5_0;
            v42 = UH8_InputListNil();
            v43 = UH8_InputListCons(v1, v42);
            v44 = UH8_InputListNil();
            v45 = UH8_InputListCons(v1, v44);
            return closure_51(v41, v43, v45);
        },
        else => unreachable,
    }
}
fn input_list_remove_55(p0: *UH9, p1: *UH8) *UH8 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH8 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_54(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_55(v0, v4);
                    return UH8_InputListCons(v3, v7);
                }
            },
            0 => {
                return UH8_InputListNil();
            },
            else => unreachable,
        }
    }
}
fn input_list_subset_56(p0: *UH8, p1: *UH8) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_53(v2, v1);
                if (v4) {
                    v0 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn closure1(ctx: *anyopaque, p2: *UH9) bool {
    const env: *ClosureEnv1 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: bool = env.v0; _ = &v0;
    var v1: *UH2 = env.v1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v22: bool = undefined; _ = &v22;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: US3 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: US3 = undefined; _ = &v14;
    var v15: *UH9 = undefined; _ = &v15;
    var v16: *UH8 = undefined; _ = &v16;
    var v17: *UH8 = undefined; _ = &v17;
    var v18: *UH8 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    if (v0) {
        v3 = US3_TriA();
        v4 = UH9_InputCons(v3, v2);
        v5 = US3_TriA();
        v6 = UH2_RegexChar(v5);
        v7 = US3_TriB();
        v8 = UH2_RegexChar(v7);
        v9 = UH2_RegexAlt(v6, v8);
        v10 = UH2_RegexStar(v9);
        v11 = US3_TriC();
        v12 = UH2_RegexChar(v11);
        v13 = UH2_RegexCat(v10, v12);
        v14 = US3_TriA();
        v15 = UH9_InputCons(v14, v2);
        v16 = language_remainders_49(v13, v15);
        v17 = input_list_remove_55(v4, v16);
        v18 = language_remainders_49(v1, v2);
        v19 = input_list_subset_56(v17, v18);
        if (v19) {
            v22 = input_list_subset_56(v18, v17);
        } else {
            v22 = false;
        }
    } else {
        v22 = false;
    }
    return v22;
}
fn closureCreate1(p0: bool, p1: *UH2) Fun1 {
    return .{ .ctx = spiralCreate(ClosureEnv1, .{ .v0 = p0, .v1 = p1, }), .call = &closure1 };
}
fn derivative_universal_remainder_family_suffixes_57(p0: Fun1, p1: *UH8) bool {
    var v0: Fun1 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = v0.call(v0.ctx, v2);
                if (v4) {
                    v1 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn spiralMainValue() []const u8 {
    var v65: bool = undefined; _ = &v65;
    var v57: US0 = undefined; _ = &v57;
    var v61: US4 = undefined; _ = &v61;
    var v62: bool = undefined; _ = &v62;
    var v84: bool = undefined; _ = &v84;
    var v77: US3 = undefined; _ = &v77;
    var v80: US4 = undefined; _ = &v80;
    var v81: bool = undefined; _ = &v81;
    var v115: bool = undefined; _ = &v115;
    var v107: US0 = undefined; _ = &v107;
    var v111: US4 = undefined; _ = &v111;
    var v112: bool = undefined; _ = &v112;
    var v156: bool = undefined; _ = &v156;
    var v149: US3 = undefined; _ = &v149;
    var v152: US4 = undefined; _ = &v152;
    var v153: bool = undefined; _ = &v153;
    var v251: bool = undefined; _ = &v251;
    var v232: US0 = undefined; _ = &v232;
    var v233: *UH6 = undefined; _ = &v233;
    var v234: US0 = undefined; _ = &v234;
    var v235: *UH0 = undefined; _ = &v235;
    var v236: US0 = undefined; _ = &v236;
    var v237: *UH0 = undefined; _ = &v237;
    var v238: *UH0 = undefined; _ = &v238;
    var v239: *UH0 = undefined; _ = &v239;
    var v240: US0 = undefined; _ = &v240;
    var v241: *UH0 = undefined; _ = &v241;
    var v242: *UH0 = undefined; _ = &v242;
    var v243: US0 = undefined; _ = &v243;
    var v244: *UH6 = undefined; _ = &v244;
    var v245: *UH5 = undefined; _ = &v245;
    var v246: *UH5 = undefined; _ = &v246;
    var v247: *UH5 = undefined; _ = &v247;
    var v248: bool = undefined; _ = &v248;
    var v271: bool = undefined; _ = &v271;
    var v252: US3 = undefined; _ = &v252;
    var v253: *UH9 = undefined; _ = &v253;
    var v254: US3 = undefined; _ = &v254;
    var v255: *UH2 = undefined; _ = &v255;
    var v256: US3 = undefined; _ = &v256;
    var v257: *UH2 = undefined; _ = &v257;
    var v258: *UH2 = undefined; _ = &v258;
    var v259: *UH2 = undefined; _ = &v259;
    var v260: US3 = undefined; _ = &v260;
    var v261: *UH2 = undefined; _ = &v261;
    var v262: *UH2 = undefined; _ = &v262;
    var v263: US3 = undefined; _ = &v263;
    var v264: *UH9 = undefined; _ = &v264;
    var v265: *UH8 = undefined; _ = &v265;
    var v266: *UH8 = undefined; _ = &v266;
    var v267: *UH8 = undefined; _ = &v267;
    var v268: bool = undefined; _ = &v268;
    var v308: bool = undefined; _ = &v308;
    var v300: US0 = undefined; _ = &v300;
    var v304: US4 = undefined; _ = &v304;
    var v305: bool = undefined; _ = &v305;
    const v0: US0 = US0_BitZero();
    const v1: *UH0 = UH0_RegexChar(v0);
    const v2: US0 = US0_BitOne();
    const v3: *UH0 = UH0_RegexChar(v2);
    const v4: *UH0 = UH0_RegexAlt(v1, v3);
    const v5: *UH0 = UH0_RegexStar(v4);
    const v6: US0 = US0_BitZero();
    const v7: *UH0 = UH0_RegexChar(v6);
    const v8: *UH0 = UH0_RegexCat(v5, v7);
    const v9: US0 = US0_BitZero();
    const v10: *UH1 = derivative_equation_proof_make_0(v8, v9);
    const v11: US3 = US3_TriA();
    const v12: *UH2 = UH2_RegexChar(v11);
    const v13: US3 = US3_TriB();
    const v14: *UH2 = UH2_RegexChar(v13);
    const v15: *UH2 = UH2_RegexAlt(v12, v14);
    const v16: *UH2 = UH2_RegexStar(v15);
    const v17: US3 = US3_TriC();
    const v18: *UH2 = UH2_RegexChar(v17);
    const v19: *UH2 = UH2_RegexCat(v16, v18);
    const v20: US3 = US3_TriA();
    const v21: *UH3 = derivative_equation_proof_make_2(v19, v20);
    const v22: US0 = US0_BitZero();
    const v23: *UH0 = UH0_RegexChar(v22);
    const v24: US0 = US0_BitOne();
    const v25: *UH0 = UH0_RegexChar(v24);
    const v26: *UH0 = UH0_RegexAlt(v23, v25);
    const v27: *UH0 = UH0_RegexStar(v26);
    const v28: US0 = US0_BitZero();
    const v29: *UH0 = UH0_RegexChar(v28);
    const v30: *UH0 = UH0_RegexCat(v27, v29);
    const v31: US0 = US0_BitZero();
    const v32: *UH1 = derivative_equation_proof_make_0(v30, v31);
    const v33: US3 = US3_TriA();
    const v34: *UH2 = UH2_RegexChar(v33);
    const v35: US3 = US3_TriB();
    const v36: *UH2 = UH2_RegexChar(v35);
    const v37: *UH2 = UH2_RegexAlt(v34, v36);
    const v38: *UH2 = UH2_RegexStar(v37);
    const v39: US3 = US3_TriC();
    const v40: *UH2 = UH2_RegexChar(v39);
    const v41: *UH2 = UH2_RegexCat(v38, v40);
    const v42: US3 = US3_TriA();
    const v43: *UH3 = derivative_equation_proof_make_2(v41, v42);
    const v44: bool = derivative_equation_proof_valid_4(v10);
    if (v44) {
    } else {
        if (spiral_true) spiralFail("suffix-independent bit derivative equation proof must validate");
    }
    const v45: bool = derivative_equation_proof_valid_18(v21);
    if (v45) {
    } else {
        if (spiral_true) spiralFail("suffix-independent ternary derivative equation proof must validate");
    }
    const v46: US0 = US0_BitZero();
    const v47: *UH0 = UH0_RegexChar(v46);
    const v48: US0 = US0_BitOne();
    const v49: *UH0 = UH0_RegexChar(v48);
    const v50: *UH0 = UH0_RegexAlt(v47, v49);
    const v51: *UH0 = UH0_RegexStar(v50);
    const v52: US0 = US0_BitZero();
    const v53: *UH0 = UH0_RegexChar(v52);
    const v54: *UH0 = UH0_RegexCat(v51, v53);
    const v55: *UH0 = derivative_equation_proof_source_5(v32);
    const v56: bool = regex_equal_14(v54, v55);
    if (v56) {
        v57 = derivative_equation_proof_symbol_6(v32);
        switch (v57.tag) {
            1 => {
                v61 = US4_SymbolLess();
            },
            0 => {
                v61 = US4_SymbolSame();
            },
            else => unreachable,
        }
        switch (v61.tag) {
            1 => {
                v62 = true;
            },
            else => {
                v62 = false;
            },
        }
        if (v62) {
            v65 = derivative_equation_proof_valid_4(v32);
        } else {
            v65 = false;
        }
    } else {
        v65 = false;
    }
    if (v65) {
    } else {
        if (spiral_true) spiralFail("bit derivative equation certificate must bind source and symbol");
    }
    const v66: US3 = US3_TriA();
    const v67: *UH2 = UH2_RegexChar(v66);
    const v68: US3 = US3_TriB();
    const v69: *UH2 = UH2_RegexChar(v68);
    const v70: *UH2 = UH2_RegexAlt(v67, v69);
    const v71: *UH2 = UH2_RegexStar(v70);
    const v72: US3 = US3_TriC();
    const v73: *UH2 = UH2_RegexChar(v72);
    const v74: *UH2 = UH2_RegexCat(v71, v73);
    const v75: *UH2 = derivative_equation_proof_source_19(v43);
    const v76: bool = regex_equal_28(v74, v75);
    if (v76) {
        v77 = derivative_equation_proof_symbol_20(v43);
        switch (v77.tag) {
            0 => {
                v80 = US4_SymbolSame();
            },
            else => {
                v80 = US4_SymbolLess();
            },
        }
        switch (v80.tag) {
            1 => {
                v81 = true;
            },
            else => {
                v81 = false;
            },
        }
        if (v81) {
            v84 = derivative_equation_proof_valid_18(v43);
        } else {
            v84 = false;
        }
    } else {
        v84 = false;
    }
    if (v84) {
    } else {
        if (spiral_true) spiralFail("ternary derivative equation certificate must bind source and symbol");
    }
    const v85: US0 = US0_BitZero();
    const v86: *UH0 = UH0_RegexChar(v85);
    const v87: US0 = US0_BitOne();
    const v88: *UH0 = UH0_RegexChar(v87);
    const v89: *UH0 = UH0_RegexAlt(v86, v88);
    const v90: *UH0 = UH0_RegexStar(v89);
    const v91: US0 = US0_BitZero();
    const v92: *UH0 = UH0_RegexChar(v91);
    const v93: *UH0 = UH0_RegexCat(v90, v92);
    const v94: US0 = US0_BitZero();
    const v95: *UH1 = derivative_equation_proof_make_0(v93, v94);
    const v96: US0 = US0_BitZero();
    const v97: *UH0 = UH0_RegexChar(v96);
    const v98: US0 = US0_BitOne();
    const v99: *UH0 = UH0_RegexChar(v98);
    const v100: *UH0 = UH0_RegexAlt(v97, v99);
    const v101: *UH0 = UH0_RegexStar(v100);
    const v102: US0 = US0_BitZero();
    const v103: *UH0 = UH0_RegexChar(v102);
    const v104: *UH0 = UH0_RegexCat(v101, v103);
    const v105: *UH0 = derivative_equation_proof_source_5(v95);
    const v106: bool = regex_equal_14(v104, v105);
    if (v106) {
        v107 = derivative_equation_proof_symbol_6(v95);
        switch (v107.tag) {
            1 => {
                v111 = US4_SymbolLess();
            },
            0 => {
                v111 = US4_SymbolSame();
            },
            else => unreachable,
        }
        switch (v111.tag) {
            1 => {
                v112 = true;
            },
            else => {
                v112 = false;
            },
        }
        if (v112) {
            v115 = derivative_equation_proof_valid_4(v95);
        } else {
            v115 = false;
        }
    } else {
        v115 = false;
    }
    const v116: US0 = US0_BitZero();
    const v117: *UH0 = UH0_RegexChar(v116);
    const v118: US0 = US0_BitOne();
    const v119: *UH0 = UH0_RegexChar(v118);
    const v120: *UH0 = UH0_RegexAlt(v117, v119);
    const v121: *UH0 = UH0_RegexStar(v120);
    const v122: US0 = US0_BitZero();
    const v123: *UH0 = UH0_RegexChar(v122);
    const v124: *UH0 = UH0_RegexCat(v121, v123);
    const v125: US0 = US0_BitZero();
    const v126: *UH0 = canonical_derivative_8(v124, v125);
    const v127: US3 = US3_TriA();
    const v128: *UH2 = UH2_RegexChar(v127);
    const v129: US3 = US3_TriB();
    const v130: *UH2 = UH2_RegexChar(v129);
    const v131: *UH2 = UH2_RegexAlt(v128, v130);
    const v132: *UH2 = UH2_RegexStar(v131);
    const v133: US3 = US3_TriC();
    const v134: *UH2 = UH2_RegexChar(v133);
    const v135: *UH2 = UH2_RegexCat(v132, v134);
    const v136: US3 = US3_TriA();
    const v137: *UH3 = derivative_equation_proof_make_2(v135, v136);
    const v138: US3 = US3_TriA();
    const v139: *UH2 = UH2_RegexChar(v138);
    const v140: US3 = US3_TriB();
    const v141: *UH2 = UH2_RegexChar(v140);
    const v142: *UH2 = UH2_RegexAlt(v139, v141);
    const v143: *UH2 = UH2_RegexStar(v142);
    const v144: US3 = US3_TriC();
    const v145: *UH2 = UH2_RegexChar(v144);
    const v146: *UH2 = UH2_RegexCat(v143, v145);
    const v147: *UH2 = derivative_equation_proof_source_19(v137);
    const v148: bool = regex_equal_28(v146, v147);
    if (v148) {
        v149 = derivative_equation_proof_symbol_20(v137);
        switch (v149.tag) {
            0 => {
                v152 = US4_SymbolSame();
            },
            else => {
                v152 = US4_SymbolLess();
            },
        }
        switch (v152.tag) {
            1 => {
                v153 = true;
            },
            else => {
                v153 = false;
            },
        }
        if (v153) {
            v156 = derivative_equation_proof_valid_18(v137);
        } else {
            v156 = false;
        }
    } else {
        v156 = false;
    }
    const v157: US3 = US3_TriA();
    const v158: *UH2 = UH2_RegexChar(v157);
    const v159: US3 = US3_TriB();
    const v160: *UH2 = UH2_RegexChar(v159);
    const v161: *UH2 = UH2_RegexAlt(v158, v160);
    const v162: *UH2 = UH2_RegexStar(v161);
    const v163: US3 = US3_TriC();
    const v164: *UH2 = UH2_RegexChar(v163);
    const v165: *UH2 = UH2_RegexCat(v162, v164);
    const v166: US3 = US3_TriA();
    const v167: *UH2 = canonical_derivative_22(v165, v166);
    const v168: US0 = US0_BitZero();
    const v169: US0 = US0_BitOne();
    const v170: *UH4 = UH4_SymbolListNil();
    const v171: *UH4 = UH4_SymbolListCons(v169, v170);
    const v172: *UH4 = UH4_SymbolListCons(v168, v171);
    const v173: *UH5 = input_singletons_from_symbols_32(v172);
    const v174: *UH6 = UH6_InputEmpty();
    const v175: *UH5 = UH5_InputListCons(v174, v173);
    const v176: US0 = US0_BitZero();
    const v177: US0 = US0_BitOne();
    const v178: *UH4 = UH4_SymbolListNil();
    const v179: *UH4 = UH4_SymbolListCons(v177, v178);
    const v180: *UH4 = UH4_SymbolListCons(v176, v179);
    const v181: US0 = US0_BitZero();
    const v182: US0 = US0_BitOne();
    const v183: *UH4 = UH4_SymbolListNil();
    const v184: *UH4 = UH4_SymbolListCons(v182, v183);
    const v185: *UH4 = UH4_SymbolListCons(v181, v184);
    const v186: *UH5 = input_singletons_from_symbols_32(v185);
    const v187: *UH5 = input_prepend_symbols_to_corpus_33(v180, v186);
    const v188: *UH5 = input_list_append_34(v175, v187);
    const v189: US3 = US3_TriA();
    const v190: US3 = US3_TriB();
    const v191: US3 = US3_TriC();
    const v192: *UH7 = UH7_SymbolListNil();
    const v193: *UH7 = UH7_SymbolListCons(v191, v192);
    const v194: *UH7 = UH7_SymbolListCons(v190, v193);
    const v195: *UH7 = UH7_SymbolListCons(v189, v194);
    const v196: *UH8 = input_singletons_from_symbols_36(v195);
    const v197: *UH9 = UH9_InputEmpty();
    const v198: *UH8 = UH8_InputListCons(v197, v196);
    const v199: US3 = US3_TriA();
    const v200: US3 = US3_TriB();
    const v201: US3 = US3_TriC();
    const v202: *UH7 = UH7_SymbolListNil();
    const v203: *UH7 = UH7_SymbolListCons(v201, v202);
    const v204: *UH7 = UH7_SymbolListCons(v200, v203);
    const v205: *UH7 = UH7_SymbolListCons(v199, v204);
    const v206: US3 = US3_TriA();
    const v207: US3 = US3_TriB();
    const v208: US3 = US3_TriC();
    const v209: *UH7 = UH7_SymbolListNil();
    const v210: *UH7 = UH7_SymbolListCons(v208, v209);
    const v211: *UH7 = UH7_SymbolListCons(v207, v210);
    const v212: *UH7 = UH7_SymbolListCons(v206, v211);
    const v213: *UH8 = input_singletons_from_symbols_36(v212);
    const v214: *UH8 = input_prepend_symbols_to_corpus_37(v205, v213);
    const v215: *UH8 = input_list_append_38(v198, v214);
    const v216: Fun0 = closureCreate0(v115, v126);
    const v217: bool = derivative_universal_remainder_family_suffixes_48(v216, v188);
    if (v217) {
    } else {
        if (spiral_true) spiralFail("one bit structural certificate must instantiate over every finite suffix probe");
    }
    const v218: Fun1 = closureCreate1(v156, v167);
    const v219: bool = derivative_universal_remainder_family_suffixes_57(v218, v215);
    if (v219) {
    } else {
        if (spiral_true) spiralFail("one ternary structural certificate must instantiate over every finite suffix probe");
    }
    const v220: US0 = US0_BitOne();
    const v221: US0 = US0_BitOne();
    const v222: US0 = US0_BitZero();
    const v223: *UH6 = UH6_InputEmpty();
    const v224: *UH6 = UH6_InputCons(v222, v223);
    const v225: *UH6 = UH6_InputCons(v221, v224);
    const v226: *UH6 = UH6_InputCons(v220, v225);
    const v227: US3 = US3_TriB();
    const v228: US3 = US3_TriC();
    const v229: *UH9 = UH9_InputEmpty();
    const v230: *UH9 = UH9_InputCons(v228, v229);
    const v231: *UH9 = UH9_InputCons(v227, v230);
    if (v115) {
        v232 = US0_BitZero();
        v233 = UH6_InputCons(v232, v226);
        v234 = US0_BitZero();
        v235 = UH0_RegexChar(v234);
        v236 = US0_BitOne();
        v237 = UH0_RegexChar(v236);
        v238 = UH0_RegexAlt(v235, v237);
        v239 = UH0_RegexStar(v238);
        v240 = US0_BitZero();
        v241 = UH0_RegexChar(v240);
        v242 = UH0_RegexCat(v239, v241);
        v243 = US0_BitZero();
        v244 = UH6_InputCons(v243, v226);
        v245 = language_remainders_40(v242, v244);
        v246 = input_list_remove_46(v233, v245);
        v247 = language_remainders_40(v126, v226);
        v248 = input_list_subset_47(v246, v247);
        if (v248) {
            v251 = input_list_subset_47(v247, v246);
        } else {
            v251 = false;
        }
    } else {
        v251 = false;
    }
    if (v251) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    if (v156) {
        v252 = US3_TriA();
        v253 = UH9_InputCons(v252, v231);
        v254 = US3_TriA();
        v255 = UH2_RegexChar(v254);
        v256 = US3_TriB();
        v257 = UH2_RegexChar(v256);
        v258 = UH2_RegexAlt(v255, v257);
        v259 = UH2_RegexStar(v258);
        v260 = US3_TriC();
        v261 = UH2_RegexChar(v260);
        v262 = UH2_RegexCat(v259, v261);
        v263 = US3_TriA();
        v264 = UH9_InputCons(v263, v231);
        v265 = language_remainders_49(v262, v264);
        v266 = input_list_remove_55(v253, v265);
        v267 = language_remainders_49(v167, v231);
        v268 = input_list_subset_56(v266, v267);
        if (v268) {
            v271 = input_list_subset_56(v267, v266);
        } else {
            v271 = false;
        }
    } else {
        v271 = false;
    }
    if (v271) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v272: *UH0 = UH0_RegexEpsilon();
    const v273: US0 = US0_BitZero();
    const v274: *UH1 = derivative_equation_proof_make_0(v272, v273);
    const v275: US0 = US0_BitZero();
    const v276: *UH0 = UH0_RegexChar(v275);
    const v277: US0 = US0_BitZero();
    const v278: *UH1 = derivative_equation_proof_make_0(v276, v277);
    const v279: *UH0 = UH0_RegexEpsilon();
    const v280: US0 = US0_BitZero();
    const v281: *UH1 = derivative_equation_proof_make_0(v279, v280);
    const v282: US0 = US0_BitZero();
    const v283: US0 = US0_BitZero();
    const v284: US0 = US0_BitZero();
    const v285: *UH1 = UH1_DerivativeEquationProofChar(v283, v284);
    const v286: US0 = US0_BitOne();
    const v287: US0 = US0_BitOne();
    const v288: *UH1 = UH1_DerivativeEquationProofChar(v286, v287);
    const v289: *UH1 = UH1_DerivativeEquationProofAlt(v282, v285, v288);
    const v290: bool = derivative_equation_proof_valid_4(v289);
    const v291: bool = v290 == false;
    if (v291) {
    } else {
        if (spiral_true) spiralFail("a child proof from another symbol context must be rejected");
    }
    const v292: US0 = US0_BitZero();
    const v293: US1 = US1_EquationCatNonNullable();
    const v294: *UH1 = UH1_DerivativeEquationProofCat(v292, v293, v274, v278);
    const v295: bool = derivative_equation_proof_valid_4(v294);
    const v296: bool = v295 == false;
    if (v296) {
    } else {
        if (spiral_true) spiralFail("a forged nullable concatenation branch must be rejected");
    }
    const v297: *UH0 = UH0_RegexEmpty();
    const v298: *UH0 = derivative_equation_proof_source_5(v281);
    const v299: bool = regex_equal_14(v297, v298);
    if (v299) {
        v300 = derivative_equation_proof_symbol_6(v281);
        switch (v300.tag) {
            1 => {
                v304 = US4_SymbolLess();
            },
            0 => {
                v304 = US4_SymbolSame();
            },
            else => unreachable,
        }
        switch (v304.tag) {
            1 => {
                v305 = true;
            },
            else => {
                v305 = false;
            },
        }
        if (v305) {
            v308 = derivative_equation_proof_valid_4(v281);
        } else {
            v308 = false;
        }
    } else {
        v308 = false;
    }
    const v309: bool = v308 == false;
    if (v309) {
    } else {
        if (spiral_true) spiralFail("a forged source binding must be rejected");
    }
    const v310: []const u8 = "brzozowski-derivative-universal-witness-green";
    return v310;
}
fn spiralMain() i32 {
    _ = spiralMainValue();
    return 0;
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
