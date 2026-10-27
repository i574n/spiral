fn spiral_abi_libc_qsort3_pack(first: i32, second: i32, third: i32) i32 {
    var a = first;
    var b = second;
    var c = third;
    if (a > b) {
        const t = a;
        a = b;
        b = t;
    }
    if (b > c) {
        const t = b;
        b = c;
        c = t;
    }
    if (a > b) {
        const t = a;
        a = b;
        b = t;
    }
    return a * 100 + b * 10 + c;
}
