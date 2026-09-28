module spiral_compiler =
    let rec __spiral_lift_0_0_even env n =
        if n = 0 then env
        else __spiral_lift_0_0_odd env (n - 1)
    and __spiral_lift_0_0_odd env n =
        if n = 0 then env
        else __spiral_lift_0_0_even env (n - 1)
    // padding 01
    // padding 02
    // padding 03
    // padding 04
    // padding 05
    // padding 06
    // padding 07
    // padding 08
    // padding 09
    // padding 10
    // padding 11
    // padding 12
    // padding 13
    // padding 14
    // padding 15
    // padding 16
    // padding 17
    // padding 18
    // padding 19
    // padding 20
    // padding 21
    // padding 22
    // padding 23
    // padding 24
    // padding 25
    // padding 26
    // padding 27
    // padding 28
    // padding 29
    // padding 30
    // padding 31
    // padding 32
    // padding 33
    // padding 34
    // padding 35
    // padding 36
    // padding 37
    // padding 38
    // padding 39
    // padding 40
    // padding 41
    // padding 42
    // padding 43
    // padding 44
    // padding 45
    // padding 46
    // padding 47
    // padding 48
    // padding 49
    // padding 50

    let outer env value =
        __spiral_lift_0_0_even env value

    let result = outer 42 8
    printfn "recursive-lift:%d" result
