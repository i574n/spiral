type [<Struct>] US0 =
    | US0_North
    | US0_East
    | US0_South
    | US0_West
let v0 : US0 = US0_North
let v8 : US0 =
    match v0 with
    | US0_East -> (* East *)
        US0_South
    | US0_North -> (* North *)
        US0_East
    | US0_South -> (* South *)
        US0_West
    | US0_West -> (* West *)
        US0_North
let v16 : US0 =
    match v8 with
    | US0_East -> (* East *)
        US0_South
    | US0_North -> (* North *)
        US0_East
    | US0_South -> (* South *)
        US0_West
    | US0_West -> (* West *)
        US0_North
let v17 : US0 = US0_South
let v18 : bool =
    match v16, v17 with
    | US0_East, US0_East -> (* East *)
        true
    | US0_North, US0_North -> (* North *)
        true
    | US0_South, US0_South -> (* South *)
        true
    | US0_West, US0_West -> (* West *)
        true
    | _ ->
        false
let v19 : int32 =
    if v18 then
        100
    else
        0
let v21 : int32 =
    match v0 with
    | US0_East -> (* East *)
        2
    | US0_North -> (* North *)
        1
    | _ ->
        7
let v23 : int32 =
    match v8 with
    | US0_East -> (* East *)
        2
    | US0_North -> (* North *)
        1
    | _ ->
        7
let v24 : int32 = v23 * 3
let v25 : int32 = v21 + v24
let v27 : int32 =
    match v16 with
    | US0_East -> (* East *)
        2
    | US0_North -> (* North *)
        1
    | _ ->
        7
let v28 : int32 = v27 * 9
let v29 : int32 = v25 + v28
let v30 : int32 = v29 + v19
v30
