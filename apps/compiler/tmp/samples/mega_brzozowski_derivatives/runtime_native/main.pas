program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH1 = class;
  TUH2 = class;
  TUH3 = class;
  TUS0 = record tag: LongInt;  end;
  TUH0 = class tag: LongInt; c1_0: TUS0; c1_1: TUH0; end;
  TUS1 = record tag: LongInt;  end;
  TUH1 = class tag: LongInt; c1_0: TUS1; c1_1: TUH1; end;
  TUH2 = class tag: LongInt; c2_0: TUS0; c3_0: TUH2; c3_1: TUH2; c4_0: TUH2; c4_1: TUH2; c5_0: TUH2; end;
  TUS2 = record tag: LongInt;  end;
  TUS3 = record tag: LongInt;  end;
  TUH3 = class tag: LongInt; c2_0: TUS1; c3_0: TUH3; c3_1: TUH3; c4_0: TUH3; c4_1: TUH3; c5_0: TUH3; end;
  TUS4 = record tag: LongInt; c0_0: TUH2; c0_1: TUH0; end;
  TUS5 = record tag: LongInt; c0_0: TUH2; c0_1: TUH0; c0_2: Boolean; end;
function regex_compare_5(v0: TUH2; v1: TUH2): TUS2; forward;
function alt_insert_sorted_4(v0: TUH2; v1: TUH2): TUH2; forward;
function make_alt_3(v0: TUH2; v1: TUH2): TUH2; forward;
function regex_equal_7(v0: TUH2; v1: TUH2): Boolean; forward;
function make_cat_6(v0: TUH2; v1: TUH2): TUH2; forward;
function make_star_8(v0: TUH2): TUH2; forward;
function normalize_2(v0: TUH2): TUH2; forward;
function nullable_10(v0: TUH2): TUS3; forward;
function derivative_9(v0: TUH2; v1: TUS0): TUH2; forward;
function canonical_derivative_1(v0: TUH2; v1: TUS0): TUH2; forward;
function accepts_0(v0: TUH2; v1: TUH0): Boolean; forward;
function regex_compare_16(v0: TUH3; v1: TUH3): TUS2; forward;
function alt_insert_sorted_15(v0: TUH3; v1: TUH3): TUH3; forward;
function make_alt_14(v0: TUH3; v1: TUH3): TUH3; forward;
function regex_equal_18(v0: TUH3; v1: TUH3): Boolean; forward;
function make_cat_17(v0: TUH3; v1: TUH3): TUH3; forward;
function make_star_19(v0: TUH3): TUH3; forward;
function normalize_13(v0: TUH3): TUH3; forward;
function nullable_21(v0: TUH3): TUS3; forward;
function derivative_20(v0: TUH3; v1: TUS1): TUH3; forward;
function canonical_derivative_12(v0: TUH3; v1: TUS1): TUH3; forward;
function accepts_11(v0: TUH3; v1: TUH1): Boolean; forward;
function decide_bit_match_22(v0: TUS4): TUS5; forward;
function bit_match_value_23(v0: TUS5): Boolean; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1: TUS0;
begin
  Result.tag := 1; 
end;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: TUS0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function US1_0: TUS1;
begin
  Result.tag := 0; 
end;
function US1_1: TUS1;
begin
  Result.tag := 1; 
end;
function US1_2: TUS1;
begin
  Result.tag := 2; 
end;
function UH1_0: TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; 
end;
function UH1_1(a0: TUS1; a1: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function UH2_0: TUH2;
begin
  Result := TUH2.Create; Result.tag := 0; 
end;
function UH2_1: TUH2;
begin
  Result := TUH2.Create; Result.tag := 1; 
end;
function UH2_2(a0: TUS0): TUH2;
begin
  Result := TUH2.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH2_3(a0: TUH2; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH2_4(a0: TUH2; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH2_5(a0: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function US2_0: TUS2;
begin
  Result.tag := 0; 
end;
function US2_1: TUS2;
begin
  Result.tag := 1; 
end;
function US2_2: TUS2;
begin
  Result.tag := 2; 
end;
function regex_compare_5(v0: TUH2; v1: TUH2): TUS2;
var
  v53: TUH2;
  v54: TUH2;
  v55: TUH2;
  v56: TUH2;
  v57: TUS2;
  tmp5: TUH2;
  tmp6: TUH2;
  v28: TUH2;
  v29: TUH2;
  v34: TUH2;
  v35: TUH2;
  v36: TUS2;
  tmp12: TUH2;
  tmp13: TUH2;
  v32: TUS0;
  v10: TUS0;
  v13: TUS0;
  v44: TUH2;
  v45: TUH2;
  v46: TUH2;
  v48: TUH2;
  tmp21: TUH2;
  tmp22: TUH2;
begin
  while True do begin
      case v0.tag of
          3: begin
              v53 := v0.c3_0;
              v54 := v0.c3_1;
              case v1.tag of
                  3: begin
                      v55 := v1.c3_0;
                      v56 := v1.c3_1;
                      v57 := regex_compare_5(v53, v55);
                      case v57.tag of
                          1: begin
                              tmp5 := v54;
                              tmp6 := v56;
                              v0 := tmp5;
                              v1 := tmp6;
                              Continue;
                          end;
                          else begin
                              Result := v57;
                              Exit;
                          end;
                      end;
                  end;
                  else begin
                      Result := US2_2;
                      Exit;
                  end;
              end;
          end;
          4: begin
              v28 := v0.c4_0;
              v29 := v0.c4_1;
              case v1.tag of
                  4: begin
                      v34 := v1.c4_0;
                      v35 := v1.c4_1;
                      v36 := regex_compare_5(v28, v34);
                      case v36.tag of
                          1: begin
                              tmp12 := v29;
                              tmp13 := v35;
                              v0 := tmp12;
                              v1 := tmp13;
                              Continue;
                          end;
                          else begin
                              Result := v36;
                              Exit;
                          end;
                      end;
                  end;
                  2: begin
                      v32 := v1.c2_0;
                      Result := US2_2;
                      Exit;
                  end;
                  0: begin
                      Result := US2_2;
                      Exit;
                  end;
                  1: begin
                      Result := US2_2;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          2: begin
              v10 := v0.c2_0;
              case v1.tag of
                  2: begin
                      v13 := v1.c2_0;
                      case v10.tag of
                          1: begin
                              case v13.tag of
                                  1: begin
                                      Result := US2_1;
                                      Exit;
                                  end;
                                  0: begin
                                      Result := US2_2;
                                      Exit;
                                  end;
                              end;
                          end;
                          0: begin
                              case v13.tag of
                                  1: begin
                                      Result := US2_0;
                                      Exit;
                                  end;
                                  0: begin
                                      Result := US2_1;
                                      Exit;
                                  end;
                              end;
                          end;
                      end;
                  end;
                  0: begin
                      Result := US2_2;
                      Exit;
                  end;
                  1: begin
                      Result := US2_2;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := US2_1;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  0: begin
                      Result := US2_2;
                      Exit;
                  end;
                  1: begin
                      Result := US2_1;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          5: begin
              v44 := v0.c5_0;
              case v1.tag of
                  3: begin
                      v45 := v1.c3_0;
                      v46 := v1.c3_1;
                      Result := US2_0;
                      Exit;
                  end;
                  5: begin
                      v48 := v1.c5_0;
                      tmp21 := v44;
                      tmp22 := v48;
                      v0 := tmp21;
                      v1 := tmp22;
                      Continue;
                  end;
                  else begin
                      Result := US2_2;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function alt_insert_sorted_4(v0: TUH2; v1: TUH2): TUH2;
var
  v2: TUH2;
  v3: TUH2;
  v4: TUS2;
  v6: TUH2;
  v11: TUS2;
begin
  case v1.tag of
      3: begin
          v2 := v1.c3_0;
          v3 := v1.c3_1;
          v4 := regex_compare_5(v0, v2);
          case v4.tag of
              2: begin
                  v6 := alt_insert_sorted_4(v0, v3);
                  Result := UH2_3(v2, v6);
              end;
              0: begin
                  Result := UH2_3(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
      0: begin
          Result := v0;
      end;
      else begin
          v11 := regex_compare_5(v0, v1);
          case v11.tag of
              2: begin
                  Result := UH2_3(v1, v0);
              end;
              0: begin
                  Result := UH2_3(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function make_alt_3(v0: TUH2; v1: TUH2): TUH2;
var
  v2: TUH2;
  v3: TUH2;
  v4: TUH2;
  tmp3: TUH2;
  tmp4: TUH2;
begin
  while True do begin
      case v0.tag of
          3: begin
              v2 := v0.c3_0;
              v3 := v0.c3_1;
              v4 := alt_insert_sorted_4(v2, v1);
              tmp3 := v3;
              tmp4 := v4;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              Result := v1;
              Exit;
          end;
          else begin
              Result := alt_insert_sorted_4(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function regex_equal_7(v0: TUH2; v1: TUH2): Boolean;
var
  v18: TUH2;
  v19: TUH2;
  v20: TUH2;
  v21: TUH2;
  v22: Boolean;
  tmp5: TUH2;
  tmp6: TUH2;
  v26: TUH2;
  v27: TUH2;
  v28: TUH2;
  v29: TUH2;
  v30: Boolean;
  tmp12: TUH2;
  tmp13: TUH2;
  v4: TUS0;
  v5: TUS0;
  v15: TUS2;
  v34: TUH2;
  v35: TUH2;
  tmp19: TUH2;
  tmp20: TUH2;
begin
  while True do begin
      case v0.tag of
          3: begin
              v18 := v0.c3_0;
              v19 := v0.c3_1;
              case v1.tag of
                  3: begin
                      v20 := v1.c3_0;
                      v21 := v1.c3_1;
                      v22 := regex_equal_7(v18, v20);
                      if v22 then begin
                          tmp5 := v19;
                          tmp6 := v21;
                          v0 := tmp5;
                          v1 := tmp6;
                          Continue;
                      end else begin
                          Result := False;
                          Exit;
                      end;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          4: begin
              v26 := v0.c4_0;
              v27 := v0.c4_1;
              case v1.tag of
                  4: begin
                      v28 := v1.c4_0;
                      v29 := v1.c4_1;
                      v30 := regex_equal_7(v26, v28);
                      if v30 then begin
                          tmp12 := v27;
                          tmp13 := v29;
                          v0 := tmp12;
                          v1 := tmp13;
                          Continue;
                      end else begin
                          Result := False;
                          Exit;
                      end;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          2: begin
              v4 := v0.c2_0;
              case v1.tag of
                  2: begin
                      v5 := v1.c2_0;
                      case v4.tag of
                          1: begin
                              case v5.tag of
                                  1: begin
                                      v15 := US2_1;
                                  end;
                                  0: begin
                                      v15 := US2_2;
                                  end;
                              end;
                          end;
                          0: begin
                              case v5.tag of
                                  1: begin
                                      v15 := US2_0;
                                  end;
                                  0: begin
                                      v15 := US2_1;
                                  end;
                              end;
                          end;
                      end;
                      case v15.tag of
                          1: begin
                              Result := True;
                              Exit;
                          end;
                          else begin
                              Result := False;
                              Exit;
                          end;
                      end;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  1: begin
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          5: begin
              v34 := v0.c5_0;
              case v1.tag of
                  5: begin
                      v35 := v1.c5_0;
                      tmp19 := v34;
                      tmp20 := v35;
                      v0 := tmp19;
                      v1 := tmp20;
                      Continue;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function make_cat_6(v0: TUH2; v1: TUH2): TUH2;
var
  v12: TUH2;
  v13: TUH2;
  v14: TUH2;
  v4: TUH2;
  v5: TUH2;
  v6: Boolean;
begin
  case v0.tag of
      0: begin
          Result := UH2_0;
      end;
      else begin
          case v1.tag of
              0: begin
                  Result := UH2_0;
              end;
              else begin
                  case v0.tag of
                      1: begin
                          Result := v1;
                      end;
                      else begin
                          case v1.tag of
                              1: begin
                                  Result := v0;
                              end;
                              else begin
                                  case v0.tag of
                                      4: begin
                                          v12 := v0.c4_0;
                                          v13 := v0.c4_1;
                                          v14 := make_cat_6(v13, v1);
                                          Result := UH2_4(v12, v14);
                                      end;
                                      5: begin
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin
                                                  v5 := v1.c5_0;
                                                  v6 := regex_equal_7(v4, v5);
                                                  if v6 then begin
                                                      Result := UH2_5(v4);
                                                  end else begin
                                                      Result := UH2_4(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH2_4(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH2_4(v0, v1);
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
  end;
end;
function make_star_8(v0: TUH2): TUH2;
var
  v3: TUH2;
begin
  case v0.tag of
      0: begin
          Result := UH2_1;
      end;
      1: begin
          Result := UH2_1;
      end;
      5: begin
          v3 := v0.c5_0;
          Result := UH2_5(v3);
      end;
      else begin
          Result := UH2_5(v0);
      end;
  end;
end;
function normalize_2(v0: TUH2): TUH2;
var
  v5: TUH2;
  v6: TUH2;
  v7: TUH2;
  v8: TUH2;
  v10: TUH2;
  v11: TUH2;
  v12: TUH2;
  v13: TUH2;
  v3: TUS0;
  v15: TUH2;
  v16: TUH2;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := normalize_2(v5);
          v8 := normalize_2(v6);
          Result := make_alt_3(v7, v8);
      end;
      4: begin
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := normalize_2(v10);
          v13 := normalize_2(v11);
          Result := make_cat_6(v12, v13);
      end;
      2: begin
          v3 := v0.c2_0;
          Result := UH2_2(v3);
      end;
      0: begin
          Result := UH2_0;
      end;
      1: begin
          Result := UH2_1;
      end;
      5: begin
          v15 := v0.c5_0;
          v16 := normalize_2(v15);
          Result := make_star_8(v16);
      end;
  end;
end;
function US3_0: TUS3;
begin
  Result.tag := 0; 
end;
function US3_1: TUS3;
begin
  Result.tag := 1; 
end;
function nullable_10(v0: TUH2): TUS3;
var
  v5: TUH2;
  v6: TUH2;
  v7: TUS3;
  v8: TUS3;
  v16: TUH2;
  v17: TUH2;
  v18: TUS3;
  v19: TUS3;
  v3: TUS0;
  v25: TUH2;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := nullable_10(v5);
          v8 := nullable_10(v6);
          case v7.tag of
              0: begin
                  Result := US3_0;
              end;
              else begin
                  case v8.tag of
                      0: begin
                          Result := US3_0;
                      end;
                      else begin
                          case v7.tag of
                              1: begin
                                  case v8.tag of
                                      1: begin
                                          Result := US3_1;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
      4: begin
          v16 := v0.c4_0;
          v17 := v0.c4_1;
          v18 := nullable_10(v16);
          v19 := nullable_10(v17);
          case v18.tag of
              0: begin
                  case v19.tag of
                      0: begin
                          Result := US3_0;
                      end;
                      else begin
                          Result := US3_1;
                      end;
                  end;
              end;
              else begin
                  Result := US3_1;
              end;
          end;
      end;
      2: begin
          v3 := v0.c2_0;
          Result := US3_1;
      end;
      0: begin
          Result := US3_1;
      end;
      1: begin
          Result := US3_0;
      end;
      5: begin
          v25 := v0.c5_0;
          Result := US3_0;
      end;
  end;
end;
function derivative_9(v0: TUH2; v1: TUS0): TUH2;
var
  v19: TUH2;
  v20: TUH2;
  v21: TUH2;
  v22: TUH2;
  v24: TUH2;
  v25: TUH2;
  v26: TUS3;
  v31: TUH2;
  v27: TUH2;
  v28: TUH2;
  v29: TUH2;
  v4: TUS0;
  v14: TUS2;
  v15: Boolean;
  v35: TUH2;
  v36: TUH2;
  v37: TUH2;
begin
  case v0.tag of
      3: begin
          v19 := v0.c3_0;
          v20 := v0.c3_1;
          v21 := derivative_9(v19, v1);
          v22 := derivative_9(v20, v1);
          Result := make_alt_3(v21, v22);
      end;
      4: begin
          v24 := v0.c4_0;
          v25 := v0.c4_1;
          v26 := nullable_10(v24);
          case v26.tag of
              1: begin
                  v31 := derivative_9(v24, v1);
                  Result := make_cat_6(v31, v25);
              end;
              0: begin
                  v27 := derivative_9(v24, v1);
                  v28 := make_cat_6(v27, v25);
                  v29 := derivative_9(v25, v1);
                  Result := make_alt_3(v28, v29);
              end;
          end;
      end;
      2: begin
          v4 := v0.c2_0;
          case v4.tag of
              1: begin
                  case v1.tag of
                      1: begin
                          v14 := US2_1;
                      end;
                      0: begin
                          v14 := US2_2;
                      end;
                  end;
              end;
              0: begin
                  case v1.tag of
                      1: begin
                          v14 := US2_0;
                      end;
                      0: begin
                          v14 := US2_1;
                      end;
                  end;
              end;
          end;
          case v14.tag of
              1: begin
                  v15 := True;
              end;
              else begin
                  v15 := False;
              end;
          end;
          if v15 then begin
              Result := UH2_1;
          end else begin
              Result := UH2_0;
          end;
      end;
      0: begin
          Result := UH2_0;
      end;
      1: begin
          Result := UH2_0;
      end;
      5: begin
          v35 := v0.c5_0;
          v36 := derivative_9(v35, v1);
          v37 := make_star_8(v35);
          Result := make_cat_6(v36, v37);
      end;
  end;
end;
function canonical_derivative_1(v0: TUH2; v1: TUS0): TUH2;
var
  v2: TUH2;
  v3: TUH2;
begin
  v2 := normalize_2(v0);
  v3 := derivative_9(v2, v1);
  Result := normalize_2(v3);
end;
function accepts_0(v0: TUH2; v1: TUH0): Boolean;
var
  v6: TUS0;
  v7: TUH0;
  v8: TUH2;
  tmp3: TUH2;
  tmp4: TUH0;
  v2: TUH2;
  v3: TUS3;
begin
  while True do begin
      case v1.tag of
          1: begin
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              v8 := canonical_derivative_1(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              v2 := normalize_2(v0);
              v3 := nullable_10(v2);
              case v3.tag of
                  1: begin
                      Result := False;
                      Exit;
                  end;
                  0: begin
                      Result := True;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function UH3_0: TUH3;
begin
  Result := TUH3.Create; Result.tag := 0; 
end;
function UH3_1: TUH3;
begin
  Result := TUH3.Create; Result.tag := 1; 
end;
function UH3_2(a0: TUS1): TUH3;
begin
  Result := TUH3.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH3_3(a0: TUH3; a1: TUH3): TUH3;
begin
  Result := TUH3.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH3_4(a0: TUH3; a1: TUH3): TUH3;
begin
  Result := TUH3.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH3_5(a0: TUH3): TUH3;
begin
  Result := TUH3.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function regex_compare_16(v0: TUH3; v1: TUH3): TUS2;
var
  v59: TUH3;
  v60: TUH3;
  v61: TUH3;
  v62: TUH3;
  v63: TUS2;
  tmp5: TUH3;
  tmp6: TUH3;
  v34: TUH3;
  v35: TUH3;
  v40: TUH3;
  v41: TUH3;
  v42: TUS2;
  tmp12: TUH3;
  tmp13: TUH3;
  v38: TUS1;
  v10: TUS1;
  v13: TUS1;
  v50: TUH3;
  v51: TUH3;
  v52: TUH3;
  v54: TUH3;
  tmp21: TUH3;
  tmp22: TUH3;
begin
  while True do begin
      case v0.tag of
          3: begin
              v59 := v0.c3_0;
              v60 := v0.c3_1;
              case v1.tag of
                  3: begin
                      v61 := v1.c3_0;
                      v62 := v1.c3_1;
                      v63 := regex_compare_16(v59, v61);
                      case v63.tag of
                          1: begin
                              tmp5 := v60;
                              tmp6 := v62;
                              v0 := tmp5;
                              v1 := tmp6;
                              Continue;
                          end;
                          else begin
                              Result := v63;
                              Exit;
                          end;
                      end;
                  end;
                  else begin
                      Result := US2_2;
                      Exit;
                  end;
              end;
          end;
          4: begin
              v34 := v0.c4_0;
              v35 := v0.c4_1;
              case v1.tag of
                  4: begin
                      v40 := v1.c4_0;
                      v41 := v1.c4_1;
                      v42 := regex_compare_16(v34, v40);
                      case v42.tag of
                          1: begin
                              tmp12 := v35;
                              tmp13 := v41;
                              v0 := tmp12;
                              v1 := tmp13;
                              Continue;
                          end;
                          else begin
                              Result := v42;
                              Exit;
                          end;
                      end;
                  end;
                  2: begin
                      v38 := v1.c2_0;
                      Result := US2_2;
                      Exit;
                  end;
                  0: begin
                      Result := US2_2;
                      Exit;
                  end;
                  1: begin
                      Result := US2_2;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          2: begin
              v10 := v0.c2_0;
              case v1.tag of
                  2: begin
                      v13 := v1.c2_0;
                      case v10.tag of
                          0: begin
                              case v13.tag of
                                  0: begin
                                      Result := US2_1;
                                      Exit;
                                  end;
                                  else begin
                                      Result := US2_0;
                                      Exit;
                                  end;
                              end;
                          end;
                          else begin
                              case v13.tag of
                                  0: begin
                                      Result := US2_2;
                                      Exit;
                                  end;
                                  else begin
                                      case v10.tag of
                                          1: begin
                                              case v13.tag of
                                                  1: begin
                                                      Result := US2_1;
                                                      Exit;
                                                  end;
                                                  2: begin
                                                      Result := US2_0;
                                                      Exit;
                                                  end;
                                              end;
                                          end;
                                          2: begin
                                              case v13.tag of
                                                  1: begin
                                                      Result := US2_2;
                                                      Exit;
                                                  end;
                                                  2: begin
                                                      Result := US2_1;
                                                      Exit;
                                                  end;
                                              end;
                                          end;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
                  0: begin
                      Result := US2_2;
                      Exit;
                  end;
                  1: begin
                      Result := US2_2;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := US2_1;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  0: begin
                      Result := US2_2;
                      Exit;
                  end;
                  1: begin
                      Result := US2_1;
                      Exit;
                  end;
                  else begin
                      Result := US2_0;
                      Exit;
                  end;
              end;
          end;
          5: begin
              v50 := v0.c5_0;
              case v1.tag of
                  3: begin
                      v51 := v1.c3_0;
                      v52 := v1.c3_1;
                      Result := US2_0;
                      Exit;
                  end;
                  5: begin
                      v54 := v1.c5_0;
                      tmp21 := v50;
                      tmp22 := v54;
                      v0 := tmp21;
                      v1 := tmp22;
                      Continue;
                  end;
                  else begin
                      Result := US2_2;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function alt_insert_sorted_15(v0: TUH3; v1: TUH3): TUH3;
var
  v2: TUH3;
  v3: TUH3;
  v4: TUS2;
  v6: TUH3;
  v11: TUS2;
begin
  case v1.tag of
      3: begin
          v2 := v1.c3_0;
          v3 := v1.c3_1;
          v4 := regex_compare_16(v0, v2);
          case v4.tag of
              2: begin
                  v6 := alt_insert_sorted_15(v0, v3);
                  Result := UH3_3(v2, v6);
              end;
              0: begin
                  Result := UH3_3(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
      0: begin
          Result := v0;
      end;
      else begin
          v11 := regex_compare_16(v0, v1);
          case v11.tag of
              2: begin
                  Result := UH3_3(v1, v0);
              end;
              0: begin
                  Result := UH3_3(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function make_alt_14(v0: TUH3; v1: TUH3): TUH3;
var
  v2: TUH3;
  v3: TUH3;
  v4: TUH3;
  tmp3: TUH3;
  tmp4: TUH3;
begin
  while True do begin
      case v0.tag of
          3: begin
              v2 := v0.c3_0;
              v3 := v0.c3_1;
              v4 := alt_insert_sorted_15(v2, v1);
              tmp3 := v3;
              tmp4 := v4;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              Result := v1;
              Exit;
          end;
          else begin
              Result := alt_insert_sorted_15(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function regex_equal_18(v0: TUH3; v1: TUH3): Boolean;
var
  v24: TUH3;
  v25: TUH3;
  v26: TUH3;
  v27: TUH3;
  v28: Boolean;
  tmp5: TUH3;
  tmp6: TUH3;
  v32: TUH3;
  v33: TUH3;
  v34: TUH3;
  v35: TUH3;
  v36: Boolean;
  tmp12: TUH3;
  tmp13: TUH3;
  v4: TUS1;
  v5: TUS1;
  v21: TUS2;
  v40: TUH3;
  v41: TUH3;
  tmp19: TUH3;
  tmp20: TUH3;
begin
  while True do begin
      case v0.tag of
          3: begin
              v24 := v0.c3_0;
              v25 := v0.c3_1;
              case v1.tag of
                  3: begin
                      v26 := v1.c3_0;
                      v27 := v1.c3_1;
                      v28 := regex_equal_18(v24, v26);
                      if v28 then begin
                          tmp5 := v25;
                          tmp6 := v27;
                          v0 := tmp5;
                          v1 := tmp6;
                          Continue;
                      end else begin
                          Result := False;
                          Exit;
                      end;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          4: begin
              v32 := v0.c4_0;
              v33 := v0.c4_1;
              case v1.tag of
                  4: begin
                      v34 := v1.c4_0;
                      v35 := v1.c4_1;
                      v36 := regex_equal_18(v32, v34);
                      if v36 then begin
                          tmp12 := v33;
                          tmp13 := v35;
                          v0 := tmp12;
                          v1 := tmp13;
                          Continue;
                      end else begin
                          Result := False;
                          Exit;
                      end;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          2: begin
              v4 := v0.c2_0;
              case v1.tag of
                  2: begin
                      v5 := v1.c2_0;
                      case v4.tag of
                          0: begin
                              case v5.tag of
                                  0: begin
                                      v21 := US2_1;
                                  end;
                                  else begin
                                      v21 := US2_0;
                                  end;
                              end;
                          end;
                          else begin
                              case v5.tag of
                                  0: begin
                                      v21 := US2_2;
                                  end;
                                  else begin
                                      case v4.tag of
                                          1: begin
                                              case v5.tag of
                                                  1: begin
                                                      v21 := US2_1;
                                                  end;
                                                  2: begin
                                                      v21 := US2_0;
                                                  end;
                                              end;
                                          end;
                                          2: begin
                                              case v5.tag of
                                                  1: begin
                                                      v21 := US2_2;
                                                  end;
                                                  2: begin
                                                      v21 := US2_1;
                                                  end;
                                              end;
                                          end;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                      case v21.tag of
                          1: begin
                              Result := True;
                              Exit;
                          end;
                          else begin
                              Result := False;
                              Exit;
                          end;
                      end;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  1: begin
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          5: begin
              v40 := v0.c5_0;
              case v1.tag of
                  5: begin
                      v41 := v1.c5_0;
                      tmp19 := v40;
                      tmp20 := v41;
                      v0 := tmp19;
                      v1 := tmp20;
                      Continue;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function make_cat_17(v0: TUH3; v1: TUH3): TUH3;
var
  v12: TUH3;
  v13: TUH3;
  v14: TUH3;
  v4: TUH3;
  v5: TUH3;
  v6: Boolean;
begin
  case v0.tag of
      0: begin
          Result := UH3_0;
      end;
      else begin
          case v1.tag of
              0: begin
                  Result := UH3_0;
              end;
              else begin
                  case v0.tag of
                      1: begin
                          Result := v1;
                      end;
                      else begin
                          case v1.tag of
                              1: begin
                                  Result := v0;
                              end;
                              else begin
                                  case v0.tag of
                                      4: begin
                                          v12 := v0.c4_0;
                                          v13 := v0.c4_1;
                                          v14 := make_cat_17(v13, v1);
                                          Result := UH3_4(v12, v14);
                                      end;
                                      5: begin
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin
                                                  v5 := v1.c5_0;
                                                  v6 := regex_equal_18(v4, v5);
                                                  if v6 then begin
                                                      Result := UH3_5(v4);
                                                  end else begin
                                                      Result := UH3_4(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH3_4(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH3_4(v0, v1);
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
  end;
end;
function make_star_19(v0: TUH3): TUH3;
var
  v3: TUH3;
begin
  case v0.tag of
      0: begin
          Result := UH3_1;
      end;
      1: begin
          Result := UH3_1;
      end;
      5: begin
          v3 := v0.c5_0;
          Result := UH3_5(v3);
      end;
      else begin
          Result := UH3_5(v0);
      end;
  end;
end;
function normalize_13(v0: TUH3): TUH3;
var
  v5: TUH3;
  v6: TUH3;
  v7: TUH3;
  v8: TUH3;
  v10: TUH3;
  v11: TUH3;
  v12: TUH3;
  v13: TUH3;
  v3: TUS1;
  v15: TUH3;
  v16: TUH3;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := normalize_13(v5);
          v8 := normalize_13(v6);
          Result := make_alt_14(v7, v8);
      end;
      4: begin
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := normalize_13(v10);
          v13 := normalize_13(v11);
          Result := make_cat_17(v12, v13);
      end;
      2: begin
          v3 := v0.c2_0;
          Result := UH3_2(v3);
      end;
      0: begin
          Result := UH3_0;
      end;
      1: begin
          Result := UH3_1;
      end;
      5: begin
          v15 := v0.c5_0;
          v16 := normalize_13(v15);
          Result := make_star_19(v16);
      end;
  end;
end;
function nullable_21(v0: TUH3): TUS3;
var
  v5: TUH3;
  v6: TUH3;
  v7: TUS3;
  v8: TUS3;
  v16: TUH3;
  v17: TUH3;
  v18: TUS3;
  v19: TUS3;
  v3: TUS1;
  v25: TUH3;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := nullable_21(v5);
          v8 := nullable_21(v6);
          case v7.tag of
              0: begin
                  Result := US3_0;
              end;
              else begin
                  case v8.tag of
                      0: begin
                          Result := US3_0;
                      end;
                      else begin
                          case v7.tag of
                              1: begin
                                  case v8.tag of
                                      1: begin
                                          Result := US3_1;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
      4: begin
          v16 := v0.c4_0;
          v17 := v0.c4_1;
          v18 := nullable_21(v16);
          v19 := nullable_21(v17);
          case v18.tag of
              0: begin
                  case v19.tag of
                      0: begin
                          Result := US3_0;
                      end;
                      else begin
                          Result := US3_1;
                      end;
                  end;
              end;
              else begin
                  Result := US3_1;
              end;
          end;
      end;
      2: begin
          v3 := v0.c2_0;
          Result := US3_1;
      end;
      0: begin
          Result := US3_1;
      end;
      1: begin
          Result := US3_0;
      end;
      5: begin
          v25 := v0.c5_0;
          Result := US3_0;
      end;
  end;
end;
function derivative_20(v0: TUH3; v1: TUS1): TUH3;
var
  v25: TUH3;
  v26: TUH3;
  v27: TUH3;
  v28: TUH3;
  v30: TUH3;
  v31: TUH3;
  v32: TUS3;
  v37: TUH3;
  v33: TUH3;
  v34: TUH3;
  v35: TUH3;
  v4: TUS1;
  v20: TUS2;
  v21: Boolean;
  v41: TUH3;
  v42: TUH3;
  v43: TUH3;
begin
  case v0.tag of
      3: begin
          v25 := v0.c3_0;
          v26 := v0.c3_1;
          v27 := derivative_20(v25, v1);
          v28 := derivative_20(v26, v1);
          Result := make_alt_14(v27, v28);
      end;
      4: begin
          v30 := v0.c4_0;
          v31 := v0.c4_1;
          v32 := nullable_21(v30);
          case v32.tag of
              1: begin
                  v37 := derivative_20(v30, v1);
                  Result := make_cat_17(v37, v31);
              end;
              0: begin
                  v33 := derivative_20(v30, v1);
                  v34 := make_cat_17(v33, v31);
                  v35 := derivative_20(v31, v1);
                  Result := make_alt_14(v34, v35);
              end;
          end;
      end;
      2: begin
          v4 := v0.c2_0;
          case v4.tag of
              0: begin
                  case v1.tag of
                      0: begin
                          v20 := US2_1;
                      end;
                      else begin
                          v20 := US2_0;
                      end;
                  end;
              end;
              else begin
                  case v1.tag of
                      0: begin
                          v20 := US2_2;
                      end;
                      else begin
                          case v4.tag of
                              1: begin
                                  case v1.tag of
                                      1: begin
                                          v20 := US2_1;
                                      end;
                                      2: begin
                                          v20 := US2_0;
                                      end;
                                  end;
                              end;
                              2: begin
                                  case v1.tag of
                                      1: begin
                                          v20 := US2_2;
                                      end;
                                      2: begin
                                          v20 := US2_1;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
          case v20.tag of
              1: begin
                  v21 := True;
              end;
              else begin
                  v21 := False;
              end;
          end;
          if v21 then begin
              Result := UH3_1;
          end else begin
              Result := UH3_0;
          end;
      end;
      0: begin
          Result := UH3_0;
      end;
      1: begin
          Result := UH3_0;
      end;
      5: begin
          v41 := v0.c5_0;
          v42 := derivative_20(v41, v1);
          v43 := make_star_19(v41);
          Result := make_cat_17(v42, v43);
      end;
  end;
end;
function canonical_derivative_12(v0: TUH3; v1: TUS1): TUH3;
var
  v2: TUH3;
  v3: TUH3;
begin
  v2 := normalize_13(v0);
  v3 := derivative_20(v2, v1);
  Result := normalize_13(v3);
end;
function accepts_11(v0: TUH3; v1: TUH1): Boolean;
var
  v6: TUS1;
  v7: TUH1;
  v8: TUH3;
  tmp3: TUH3;
  tmp4: TUH1;
  v2: TUH3;
  v3: TUS3;
begin
  while True do begin
      case v1.tag of
          1: begin
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              v8 := canonical_derivative_12(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              v2 := normalize_13(v0);
              v3 := nullable_21(v2);
              case v3.tag of
                  1: begin
                      Result := False;
                      Exit;
                  end;
                  0: begin
                      Result := True;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function US4_0(a0: TUH2; a1: TUH0): TUS4;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function US5_0(a0: TUH2; a1: TUH0; a2: Boolean): TUS5;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1; Result.c0_2 := a2;
end;
function decide_bit_match_22(v0: TUS4): TUS5;
var
  v1: TUH2;
  v2: TUH0;
  v3: Boolean;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          v2 := v0.c0_1;
          v3 := accepts_0(v1, v2);
          Result := US5_0(v1, v2, v3);
      end;
  end;
end;
function bit_match_value_23(v0: TUS5): Boolean;
var
  v1: TUH2;
  v2: TUH0;
  v3: Boolean;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          v2 := v0.c0_1;
          v3 := v0.c0_2;
          Result := v3;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v1: TUS0;
  v2: TUS0;
  v3: TUH0;
  v4: TUH0;
  v5: TUH0;
  v6: TUH0;
  v7: TUS0;
  v8: TUS0;
  v9: TUS0;
  v10: TUH0;
  v11: TUH0;
  v12: TUH0;
  v13: TUH0;
  v14: TUS1;
  v15: TUS1;
  v16: TUS1;
  v17: TUH1;
  v18: TUH1;
  v19: TUH1;
  v20: TUH1;
  v21: TUS1;
  v22: TUS1;
  v23: TUS1;
  v24: TUH1;
  v25: TUH1;
  v26: TUH1;
  v27: TUH1;
  v28: TUS0;
  v29: TUH2;
  v30: TUS0;
  v31: TUH2;
  v32: TUH2;
  v33: TUH2;
  v34: TUS0;
  v35: TUH2;
  v36: TUH2;
  v37: Boolean;
  v38: TUS0;
  v39: TUH2;
  v40: TUS0;
  v41: TUH2;
  v42: TUH2;
  v43: TUH2;
  v44: TUS0;
  v45: TUH2;
  v46: TUH2;
  v47: Boolean;
  v48: TUS1;
  v49: TUH3;
  v50: TUH3;
  v51: Boolean;
  v52: TUS1;
  v53: TUH3;
  v54: TUH3;
  v55: Boolean;
  v56: TUS0;
  v57: TUH2;
  v58: TUS0;
  v59: TUH2;
  v60: TUH2;
  v61: TUH2;
  v62: TUS0;
  v63: TUH2;
  v64: TUH2;
  v65: TUS4;
  v66: TUS5;
  v67: TUS0;
  v68: TUH2;
  v69: TUS0;
  v70: TUH2;
  v71: TUH2;
  v72: TUH2;
  v73: TUS0;
  v74: TUH2;
  v75: TUH2;
  v76: TUS4;
  v77: TUS5;
  v78: Boolean;
  v79: Boolean;
begin
  v0 := US0_1;
  v1 := US0_1;
  v2 := US0_0;
  v3 := UH0_0;
  v4 := UH0_1(v2, v3);
  v5 := UH0_1(v1, v4);
  v6 := UH0_1(v0, v5);
  v7 := US0_1;
  v8 := US0_1;
  v9 := US0_1;
  v10 := UH0_0;
  v11 := UH0_1(v9, v10);
  v12 := UH0_1(v8, v11);
  v13 := UH0_1(v7, v12);
  v14 := US1_0;
  v15 := US1_0;
  v16 := US1_0;
  v17 := UH1_0;
  v18 := UH1_1(v16, v17);
  v19 := UH1_1(v15, v18);
  v20 := UH1_1(v14, v19);
  v21 := US1_0;
  v22 := US1_0;
  v23 := US1_1;
  v24 := UH1_0;
  v25 := UH1_1(v23, v24);
  v26 := UH1_1(v22, v25);
  v27 := UH1_1(v21, v26);
  v28 := US0_0;
  v29 := UH2_2(v28);
  v30 := US0_1;
  v31 := UH2_2(v30);
  v32 := UH2_3(v29, v31);
  v33 := UH2_5(v32);
  v34 := US0_0;
  v35 := UH2_2(v34);
  v36 := UH2_4(v33, v35);
  v37 := accepts_0(v36, v6);
  if v37 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-expected-true'); Halt(1); end;
  end;
  v38 := US0_0;
  v39 := UH2_2(v38);
  v40 := US0_1;
  v41 := UH2_2(v40);
  v42 := UH2_3(v39, v41);
  v43 := UH2_5(v42);
  v44 := US0_0;
  v45 := UH2_2(v44);
  v46 := UH2_4(v43, v45);
  v47 := accepts_0(v46, v13);
  if v47 then begin
      begin WriteLn(StdErr, 'brzozowski-expected-false'); Halt(1); end;
  end else begin
  end;
  v48 := US1_0;
  v49 := UH3_2(v48);
  v50 := UH3_5(v49);
  v51 := accepts_11(v50, v20);
  if v51 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-expected-true'); Halt(1); end;
  end;
  v52 := US1_0;
  v53 := UH3_2(v52);
  v54 := UH3_5(v53);
  v55 := accepts_11(v54, v27);
  if v55 then begin
      begin WriteLn(StdErr, 'brzozowski-expected-false'); Halt(1); end;
  end else begin
  end;
  v56 := US0_0;
  v57 := UH2_2(v56);
  v58 := US0_1;
  v59 := UH2_2(v58);
  v60 := UH2_3(v57, v59);
  v61 := UH2_5(v60);
  v62 := US0_0;
  v63 := UH2_2(v62);
  v64 := UH2_4(v61, v63);
  v65 := US4_0(v64, v6);
  v66 := decide_bit_match_22(v65);
  v67 := US0_0;
  v68 := UH2_2(v67);
  v69 := US0_1;
  v70 := UH2_2(v69);
  v71 := UH2_3(v68, v70);
  v72 := UH2_5(v71);
  v73 := US0_0;
  v74 := UH2_2(v73);
  v75 := UH2_4(v72, v74);
  v76 := US4_0(v75, v13);
  v77 := decide_bit_match_22(v76);
  v78 := bit_match_value_23(v66);
  if v78 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-expected-true'); Halt(1); end;
  end;
  v79 := bit_match_value_23(v77);
  if v79 then begin
      begin WriteLn(StdErr, 'brzozowski-expected-false'); Halt(1); end;
  end else begin
  end;
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
