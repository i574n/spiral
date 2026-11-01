type [<Struct>] US0 =
    | US0_Foo
    | US0_FOO
    | US0_Bar
let v0 : US0 = US0_Foo
let v1 : US0 = US0_FOO
let v4 : int32 =
    match v0 with
    | US0_Bar -> (* Bar *)
        100
    | US0_FOO -> (* FOO *)
        10
    | US0_Foo -> (* Foo *)
        1
let v7 : int32 =
    match v1 with
    | US0_Bar -> (* Bar *)
        100
    | US0_FOO -> (* FOO *)
        10
    | US0_Foo -> (* Foo *)
        1
let v8 : int32 = v4 + v7
v8
