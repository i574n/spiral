let v0 : int32 = -2147483648
let v1 : uint32 = 4294967295u
let v2 : int32 = -1
let v3 : float32 = 0.0f
let v4 : float32 = 1.9f
let v5 : float32 = 2.9f
let v6 : uint32 = 4294967294u
let v7 : uint32 = 5u
let v8 : uint32 = 0u
let v9 : float32 = v3 - v4
let v10 : uint32 = uint32 v0
let v11 : int32 = int32 v10
let v12 : int32 = int32 v1
let v13 : uint32 = uint32 v2
let v14 : int32 = int32 v9
let v15 : int32 = int32 v5
let v16 : uint32 = v10 / 2u
let v17 : uint32 = v6 / 2u
let v18 : uint32 = v7 % 3u
let v19 : uint32 = ~~~v8
let v20 : uint32 = v1 >>> 31
let v21 : bool = v0 < -1
let v23 : bool =
    if v21 then
        let v22 : bool = v0 <= v0
        v22
    else
        false
let v26 : bool =
    if v23 then
        let v24 : bool = v0 > 0
        let v25 : bool = v24 = false
        v25
    else
        false
if v26 then
    let v27 : bool = v10 > 1u
    let v29 : bool =
        if v27 then
            let v28 : bool = v11 = v0
            v28
        else
            false
    let v31 : bool =
        if v29 then
            let v30 : bool = v12 = v2
            v30
        else
            false
    let v33 : bool =
        if v31 then
            let v32 : bool = v13 = v1
            v32
        else
            false
    if v33 then
        let v34 : bool = v14 = v2
        let v36 : bool =
            if v34 then
                let v35 : bool = v15 = 2
                v35
            else
                false
        if v36 then
            let v37 : bool = v16 = 1073741824u
            let v39 : bool =
                if v37 then
                    let v38 : bool = v17 = 2147483647u
                    v38
                else
                    false
            let v41 : bool =
                if v39 then
                    let v40 : bool = v18 = 2u
                    v40
                else
                    false
            if v41 then
                let v42 : bool = v19 = v1
                let v44 : bool =
                    if v42 then
                        let v43 : bool = v20 = 1u
                        v43
                    else
                        false
                if v44 then
                    0
                else
                    5
            else
                4
        else
            3
    else
        2
else
    1
