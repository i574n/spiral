import gleam/float
@external(erlang, "math", "atan2")
fn spiral_math_atan2(y: Float, x: Float) -> Float
pub fn main() {
    let v0 = 2.7
    let v1 = 3.2
    let v2 = -2.5
    let v3 = 3.5
    let v4 = 0.5
    let v5 = 1.0
    let v6 = 2.7
    let v7 = float.floor
    let v8 = v7(v0)
    let v9 = v8 != 2.0
    case v9 {
        True -> 1
        False -> {
            let v10 = float.ceiling
            let v11 = v10(v0)
            let v12 = v11 != 3.0
            case v12 {
                True -> 2
                False -> {
                    let v13 = float.floor
                    let v14 = v13(v0)
                    let v15 = v0 -. v14
                    let v16 = v15 >. 0.5
                    let v27 =
                        case v16 {
                            True -> {
                                let v17 = v14 +. 1.0
                                v17
                            }
                            False -> {
                                let v18 = v15 <. 0.5
                                case v18 {
                                    True -> v14
                                    False -> {
                                        let v19 = v14 /. 2.0
                                        let v20 = float.floor
                                        let v21 = v20(v19)
                                        let v22 = v21 *. 2.0
                                        let v23 = v22 == v14
                                        case v23 {
                                            True -> v14
                                            False -> {
                                                let v24 = v14 +. 1.0
                                                v24
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v28 = v27 != 3.0
                    case v28 {
                        True -> 3
                        False -> {
                            let v29 = float.floor
                            let v30 = v29(v1)
                            let v31 = v1 -. v30
                            let v32 = v31 >. 0.5
                            let v43 =
                                case v32 {
                                    True -> {
                                        let v33 = v30 +. 1.0
                                        v33
                                    }
                                    False -> {
                                        let v34 = v31 <. 0.5
                                        case v34 {
                                            True -> v30
                                            False -> {
                                                let v35 = v30 /. 2.0
                                                let v36 = float.floor
                                                let v37 = v36(v35)
                                                let v38 = v37 *. 2.0
                                                let v39 = v38 == v30
                                                case v39 {
                                                    True -> v30
                                                    False -> {
                                                        let v40 = v30 +. 1.0
                                                        v40
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            let v44 = v43 != 3.0
                            case v44 {
                                True -> 4
                                False -> {
                                    let v45 = float.floor
                                    let v46 = v45(v2)
                                    let v47 = v2 -. v46
                                    let v48 = v47 >. 0.5
                                    let v59 =
                                        case v48 {
                                            True -> {
                                                let v49 = v46 +. 1.0
                                                v49
                                            }
                                            False -> {
                                                let v50 = v47 <. 0.5
                                                case v50 {
                                                    True -> v46
                                                    False -> {
                                                        let v51 = v46 /. 2.0
                                                        let v52 = float.floor
                                                        let v53 = v52(v51)
                                                        let v54 = v53 *. 2.0
                                                        let v55 = v54 == v46
                                                        case v55 {
                                                            True -> v46
                                                            False -> {
                                                                let v56 = v46 +. 1.0
                                                                v56
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    let v60 = v59 != -2.0
                                    case v60 {
                                        True -> 5
                                        False -> {
                                            let v61 = float.floor
                                            let v62 = v61(v3)
                                            let v63 = v3 -. v62
                                            let v64 = v63 >. 0.5
                                            let v75 =
                                                case v64 {
                                                    True -> {
                                                        let v65 = v62 +. 1.0
                                                        v65
                                                    }
                                                    False -> {
                                                        let v66 = v63 <. 0.5
                                                        case v66 {
                                                            True -> v62
                                                            False -> {
                                                                let v67 = v62 /. 2.0
                                                                let v68 = float.floor
                                                                let v69 = v68(v67)
                                                                let v70 = v69 *. 2.0
                                                                let v71 = v70 == v62
                                                                case v71 {
                                                                    True -> v62
                                                                    False -> {
                                                                        let v72 = v62 +. 1.0
                                                                        v72
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            let v76 = v75 != 4.0
                                            case v76 {
                                                True -> 6
                                                False -> {
                                                    let v77 = float.floor
                                                    let v78 = v77(v4)
                                                    let v79 = v4 -. v78
                                                    let v80 = v79 >. 0.5
                                                    let v91 =
                                                        case v80 {
                                                            True -> {
                                                                let v81 = v78 +. 1.0
                                                                v81
                                                            }
                                                            False -> {
                                                                let v82 = v79 <. 0.5
                                                                case v82 {
                                                                    True -> v78
                                                                    False -> {
                                                                        let v83 = v78 /. 2.0
                                                                        let v84 = float.floor
                                                                        let v85 = v84(v83)
                                                                        let v86 = v85 *. 2.0
                                                                        let v87 = v86 == v78
                                                                        case v87 {
                                                                            True -> v78
                                                                            False -> {
                                                                                let v88 = v78 +. 1.0
                                                                                v88
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v92 = v91 != 0.0
                                                    case v92 {
                                                        True -> 7
                                                        False -> {
                                                            let v93 = spiral_math_atan2(v5, v5)
                                                            let v94 = v93 *. 1000.0
                                                            let v95 = float.floor
                                                            let v96 = v95(v94)
                                                            let v97 = v96 != 785.0
                                                            case v97 {
                                                                True -> 8
                                                                False -> {
                                                                    let v98 = float.floor
                                                                    let v99 = v98(v6)
                                                                    let v100 = v99 != 2.0
                                                                    case v100 {
                                                                        True -> 9
                                                                        False -> 0
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
    }
}
