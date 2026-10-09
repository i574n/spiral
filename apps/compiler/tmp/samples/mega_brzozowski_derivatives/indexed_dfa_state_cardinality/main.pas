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
  TUH0 = class tag: LongInt; c2_0: TUS0; c3_0: TUH0; c3_1: TUH0; c4_0: TUH0; c4_1: TUH0; c5_0: TUH0; end;
  TUH1 = class tag: LongInt; c1_0: TUS0; c1_1: TUH1; end;
  TTuple0 = record f0: TUH1; f1: QWord; end;
  TUS1 = record tag: LongInt;  end;
  TUS2 = record tag: LongInt;  end;
  TUS3 = record tag: LongInt;  end;
  TUH2 = class tag: LongInt; c2_0: TUS3; c3_0: TUH2; c3_1: TUH2; c4_0: TUH2; c4_1: TUH2; c5_0: TUH2; end;
  TUH3 = class tag: LongInt; c1_0: TUS3; c1_1: TUH3; end;
function random_bit_input_1(v0: QWord; v1: LongInt; v2: TUH1): TTuple0; forward;
function run_2(v0: LongInt; v1: TUH1): Boolean; forward;
function regex_compare_8(v0: TUH0; v1: TUH0): TUS1; forward;
function alt_insert_sorted_7(v0: TUH0; v1: TUH0): TUH0; forward;
function make_alt_6(v0: TUH0; v1: TUH0): TUH0; forward;
function regex_equal_10(v0: TUH0; v1: TUH0): Boolean; forward;
function make_cat_9(v0: TUH0; v1: TUH0): TUH0; forward;
function make_star_11(v0: TUH0): TUH0; forward;
function normalize_5(v0: TUH0): TUH0; forward;
function nullable_13(v0: TUH0): TUS2; forward;
function derivative_12(v0: TUH0; v1: TUS0): TUH0; forward;
function canonical_derivative_4(v0: TUH0; v1: TUS0): TUH0; forward;
function accepts_3(v0: TUH0; v1: TUH1): Boolean; forward;
function loop_0(v0: LongInt; v1: TUH0; v2: LongInt; v3: QWord; v4: LongInt): LongInt; forward;
function zeros_input_15(v0: LongInt; v1: TUH1): TUH1; forward;
function run_16(v0: LongInt; v1: TUH1): Boolean; forward;
function loop_14(v0: LongInt; v1: TUH0; v2: LongInt; v3: LongInt): LongInt; forward;
function run_17(v0: LongInt; v1: TUH3): Boolean; forward;
function regex_compare_23(v0: TUH2; v1: TUH2): TUS1; forward;
function alt_insert_sorted_22(v0: TUH2; v1: TUH2): TUH2; forward;
function make_alt_21(v0: TUH2; v1: TUH2): TUH2; forward;
function regex_equal_25(v0: TUH2; v1: TUH2): Boolean; forward;
function make_cat_24(v0: TUH2; v1: TUH2): TUH2; forward;
function make_star_26(v0: TUH2): TUH2; forward;
function normalize_20(v0: TUH2): TUH2; forward;
function nullable_28(v0: TUH2): TUS2; forward;
function derivative_27(v0: TUH2; v1: TUS3): TUH2; forward;
function canonical_derivative_19(v0: TUH2; v1: TUS3): TUH2; forward;
function accepts_18(v0: TUH2; v1: TUH3): Boolean; forward;
function US0_BitZero: TUS0;
begin
  Result.tag := 0; 
end;
function US0_BitOne: TUS0;
begin
  Result.tag := 1; 
end;
function UH0_RegexEmpty: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_RegexEpsilon: TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; 
end;
function UH0_RegexChar(a0: TUS0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH0_RegexAlt(a0: TUH0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH0_RegexCat(a0: TUH0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH0_RegexStar(a0: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function UH1_InputEmpty: TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; 
end;
function UH1_InputCons(a0: TUS0; a1: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function TupleCreate0(f0: TUH1; f1: QWord): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function random_bit_input_1(v0: QWord; v1: LongInt; v2: TUH1): TTuple0;
var
  v3: Boolean;
  v4: QWord;
  v5: QWord;
  v6: QWord;
  v7: LongInt;
  v8: QWord;
  v9: QWord;
  v10: Boolean;
  v13: TUS0;
  v11: TUS0;
  v12: TUS0;
  v14: TUH1;
  tmp12: QWord;
  tmp13: LongInt;
  tmp14: TUH1;
begin
  while True do begin
      v3 := 0 < v1;
      if v3 then begin
          v4 := v0 * 1103515245;
          v5 := v4 + 12345;
          v6 := v5 and 2147483647;
          v7 := v1 - 1;
          v8 := v6 shr 16;
          v9 := v8 and 1;
          v10 := v9 = 0;
          if v10 then begin
              v11 := US0_BitZero;
              v13 := v11;
          end else begin
              v12 := US0_BitOne;
              v13 := v12;
          end;
          v14 := UH1_InputCons(v13, v2);
          tmp12 := v6;
          tmp13 := v7;
          tmp14 := v14;
          v0 := tmp12;
          v1 := tmp13;
          v2 := tmp14;
          Continue;
      end else begin
          Result := TupleCreate0(v2, v0);
          Exit;
      end;
  end;
end;
function US1_SymbolLess: TUS1;
begin
  Result.tag := 0; 
end;
function US1_SymbolSame: TUS1;
begin
  Result.tag := 1; 
end;
function US1_SymbolGreater: TUS1;
begin
  Result.tag := 2; 
end;
function run_2(v0: LongInt; v1: TUH1): Boolean;
var
  v4: TUS0;
  v5: TUH1;
  v6: Boolean;
  v19: LongInt;
  v10: TUS1;
  v11: Boolean;
  v16: TUS1;
  v17: Boolean;
  tmp8: LongInt;
  tmp9: TUH1;
  v2: Boolean;
  v3: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin
              v4 := v1.c1_0;
              v5 := v1.c1_1;
              v6 := v0 = 0;
              if v6 then begin
                  case v4.tag of
                      1: begin
                          v10 := US1_SymbolGreater;
                      end;
                      0: begin
                          v10 := US1_SymbolSame;
                      end;
                  end;
                  case v10.tag of
                      1: begin
                          v11 := True;
                      end;
                      else begin
                          v11 := False;
                      end;
                  end;
                  if v11 then begin
                      v19 := 1;
                  end else begin
                      v19 := 0;
                  end;
              end else begin
                  case v4.tag of
                      1: begin
                          v16 := US1_SymbolGreater;
                      end;
                      0: begin
                          v16 := US1_SymbolSame;
                      end;
                  end;
                  case v16.tag of
                      1: begin
                          v17 := True;
                      end;
                      else begin
                          v17 := False;
                      end;
                  end;
                  if v17 then begin
                      v19 := 1;
                  end else begin
                      v19 := 0;
                  end;
              end;
              tmp8 := v19;
              tmp9 := v5;
              v0 := tmp8;
              v1 := tmp9;
              Continue;
          end;
          0: begin
              v2 := v0 = 0;
              v3 := v2 = False;
              Result := v3;
              Exit;
          end;
      end;
  end;
end;
function regex_compare_8(v0: TUH0; v1: TUH0): TUS1;
var
  v53: TUH0;
  v54: TUH0;
  v55: TUH0;
  v56: TUH0;
  v57: TUS1;
  tmp5: TUH0;
  tmp6: TUH0;
  v28: TUH0;
  v29: TUH0;
  v34: TUH0;
  v35: TUH0;
  v36: TUS1;
  tmp12: TUH0;
  tmp13: TUH0;
  v32: TUS0;
  v10: TUS0;
  v13: TUS0;
  v44: TUH0;
  v45: TUH0;
  v46: TUH0;
  v48: TUH0;
  tmp21: TUH0;
  tmp22: TUH0;
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
                      v57 := regex_compare_8(v53, v55);
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
                      Result := US1_SymbolGreater;
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
                      v36 := regex_compare_8(v28, v34);
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
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  0: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  1: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
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
                                      Result := US1_SymbolSame;
                                      Exit;
                                  end;
                                  0: begin
                                      Result := US1_SymbolGreater;
                                      Exit;
                                  end;
                              end;
                          end;
                          0: begin
                              case v13.tag of
                                  1: begin
                                      Result := US1_SymbolLess;
                                      Exit;
                                  end;
                                  0: begin
                                      Result := US1_SymbolSame;
                                      Exit;
                                  end;
                              end;
                          end;
                      end;
                  end;
                  0: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  1: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := US1_SymbolSame;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  0: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  1: begin
                      Result := US1_SymbolSame;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
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
                      Result := US1_SymbolLess;
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
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function alt_insert_sorted_7(v0: TUH0; v1: TUH0): TUH0;
var
  v2: TUH0;
  v3: TUH0;
  v4: TUS1;
  v6: TUH0;
  v11: TUS1;
begin
  case v1.tag of
      3: begin
          v2 := v1.c3_0;
          v3 := v1.c3_1;
          v4 := regex_compare_8(v0, v2);
          case v4.tag of
              2: begin
                  v6 := alt_insert_sorted_7(v0, v3);
                  Result := UH0_RegexAlt(v2, v6);
              end;
              0: begin
                  Result := UH0_RegexAlt(v0, v1);
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
          v11 := regex_compare_8(v0, v1);
          case v11.tag of
              2: begin
                  Result := UH0_RegexAlt(v1, v0);
              end;
              0: begin
                  Result := UH0_RegexAlt(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function make_alt_6(v0: TUH0; v1: TUH0): TUH0;
var
  v2: TUH0;
  v3: TUH0;
  v4: TUH0;
  tmp3: TUH0;
  tmp4: TUH0;
begin
  while True do begin
      case v0.tag of
          3: begin
              v2 := v0.c3_0;
              v3 := v0.c3_1;
              v4 := alt_insert_sorted_7(v2, v1);
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
              Result := alt_insert_sorted_7(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function regex_equal_10(v0: TUH0; v1: TUH0): Boolean;
var
  v18: TUH0;
  v19: TUH0;
  v20: TUH0;
  v21: TUH0;
  v22: Boolean;
  tmp5: TUH0;
  tmp6: TUH0;
  v26: TUH0;
  v27: TUH0;
  v28: TUH0;
  v29: TUH0;
  v30: Boolean;
  tmp12: TUH0;
  tmp13: TUH0;
  v4: TUS0;
  v5: TUS0;
  v15: TUS1;
  v34: TUH0;
  v35: TUH0;
  tmp19: TUH0;
  tmp20: TUH0;
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
                      v22 := regex_equal_10(v18, v20);
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
                      v30 := regex_equal_10(v26, v28);
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
                                      v15 := US1_SymbolSame;
                                  end;
                                  0: begin
                                      v15 := US1_SymbolGreater;
                                  end;
                              end;
                          end;
                          0: begin
                              case v5.tag of
                                  1: begin
                                      v15 := US1_SymbolLess;
                                  end;
                                  0: begin
                                      v15 := US1_SymbolSame;
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
function make_cat_9(v0: TUH0; v1: TUH0): TUH0;
var
  v12: TUH0;
  v13: TUH0;
  v14: TUH0;
  v4: TUH0;
  v5: TUH0;
  v6: Boolean;
begin
  case v0.tag of
      0: begin
          Result := UH0_RegexEmpty;
      end;
      else begin
          case v1.tag of
              0: begin
                  Result := UH0_RegexEmpty;
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
                                          v14 := make_cat_9(v13, v1);
                                          Result := UH0_RegexCat(v12, v14);
                                      end;
                                      5: begin
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin
                                                  v5 := v1.c5_0;
                                                  v6 := regex_equal_10(v4, v5);
                                                  if v6 then begin
                                                      Result := UH0_RegexStar(v4);
                                                  end else begin
                                                      Result := UH0_RegexCat(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH0_RegexCat(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH0_RegexCat(v0, v1);
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
function make_star_11(v0: TUH0): TUH0;
var
  v3: TUH0;
begin
  case v0.tag of
      0: begin
          Result := UH0_RegexEpsilon;
      end;
      1: begin
          Result := UH0_RegexEpsilon;
      end;
      5: begin
          v3 := v0.c5_0;
          Result := UH0_RegexStar(v3);
      end;
      else begin
          Result := UH0_RegexStar(v0);
      end;
  end;
end;
function normalize_5(v0: TUH0): TUH0;
var
  v5: TUH0;
  v6: TUH0;
  v7: TUH0;
  v8: TUH0;
  v10: TUH0;
  v11: TUH0;
  v12: TUH0;
  v13: TUH0;
  v3: TUS0;
  v15: TUH0;
  v16: TUH0;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := normalize_5(v5);
          v8 := normalize_5(v6);
          Result := make_alt_6(v7, v8);
      end;
      4: begin
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := normalize_5(v10);
          v13 := normalize_5(v11);
          Result := make_cat_9(v12, v13);
      end;
      2: begin
          v3 := v0.c2_0;
          Result := UH0_RegexChar(v3);
      end;
      0: begin
          Result := UH0_RegexEmpty;
      end;
      1: begin
          Result := UH0_RegexEpsilon;
      end;
      5: begin
          v15 := v0.c5_0;
          v16 := normalize_5(v15);
          Result := make_star_11(v16);
      end;
  end;
end;
function US2_Nullable: TUS2;
begin
  Result.tag := 0; 
end;
function US2_NonNullable: TUS2;
begin
  Result.tag := 1; 
end;
function nullable_13(v0: TUH0): TUS2;
var
  v5: TUH0;
  v6: TUH0;
  v7: TUS2;
  v8: TUS2;
  v16: TUH0;
  v17: TUH0;
  v18: TUS2;
  v19: TUS2;
  v3: TUS0;
  v25: TUH0;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := nullable_13(v5);
          v8 := nullable_13(v6);
          case v7.tag of
              0: begin
                  Result := US2_Nullable;
              end;
              else begin
                  case v8.tag of
                      0: begin
                          Result := US2_Nullable;
                      end;
                      else begin
                          case v7.tag of
                              1: begin
                                  case v8.tag of
                                      1: begin
                                          Result := US2_NonNullable;
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
          v18 := nullable_13(v16);
          v19 := nullable_13(v17);
          case v18.tag of
              0: begin
                  case v19.tag of
                      0: begin
                          Result := US2_Nullable;
                      end;
                      else begin
                          Result := US2_NonNullable;
                      end;
                  end;
              end;
              else begin
                  Result := US2_NonNullable;
              end;
          end;
      end;
      2: begin
          v3 := v0.c2_0;
          Result := US2_NonNullable;
      end;
      0: begin
          Result := US2_NonNullable;
      end;
      1: begin
          Result := US2_Nullable;
      end;
      5: begin
          v25 := v0.c5_0;
          Result := US2_Nullable;
      end;
  end;
end;
function derivative_12(v0: TUH0; v1: TUS0): TUH0;
var
  v19: TUH0;
  v20: TUH0;
  v21: TUH0;
  v22: TUH0;
  v24: TUH0;
  v25: TUH0;
  v26: TUS2;
  v31: TUH0;
  v27: TUH0;
  v28: TUH0;
  v29: TUH0;
  v4: TUS0;
  v14: TUS1;
  v15: Boolean;
  v35: TUH0;
  v36: TUH0;
  v37: TUH0;
begin
  case v0.tag of
      3: begin
          v19 := v0.c3_0;
          v20 := v0.c3_1;
          v21 := derivative_12(v19, v1);
          v22 := derivative_12(v20, v1);
          Result := make_alt_6(v21, v22);
      end;
      4: begin
          v24 := v0.c4_0;
          v25 := v0.c4_1;
          v26 := nullable_13(v24);
          case v26.tag of
              1: begin
                  v31 := derivative_12(v24, v1);
                  Result := make_cat_9(v31, v25);
              end;
              0: begin
                  v27 := derivative_12(v24, v1);
                  v28 := make_cat_9(v27, v25);
                  v29 := derivative_12(v25, v1);
                  Result := make_alt_6(v28, v29);
              end;
          end;
      end;
      2: begin
          v4 := v0.c2_0;
          case v4.tag of
              1: begin
                  case v1.tag of
                      1: begin
                          v14 := US1_SymbolSame;
                      end;
                      0: begin
                          v14 := US1_SymbolGreater;
                      end;
                  end;
              end;
              0: begin
                  case v1.tag of
                      1: begin
                          v14 := US1_SymbolLess;
                      end;
                      0: begin
                          v14 := US1_SymbolSame;
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
              Result := UH0_RegexEpsilon;
          end else begin
              Result := UH0_RegexEmpty;
          end;
      end;
      0: begin
          Result := UH0_RegexEmpty;
      end;
      1: begin
          Result := UH0_RegexEmpty;
      end;
      5: begin
          v35 := v0.c5_0;
          v36 := derivative_12(v35, v1);
          v37 := make_star_11(v35);
          Result := make_cat_9(v36, v37);
      end;
  end;
end;
function canonical_derivative_4(v0: TUH0; v1: TUS0): TUH0;
var
  v2: TUH0;
  v3: TUH0;
begin
  v2 := normalize_5(v0);
  v3 := derivative_12(v2, v1);
  Result := normalize_5(v3);
end;
function accepts_3(v0: TUH0; v1: TUH1): Boolean;
var
  v6: TUS0;
  v7: TUH1;
  v8: TUH0;
  tmp3: TUH0;
  tmp4: TUH1;
  v2: TUH0;
  v3: TUS2;
begin
  while True do begin
      case v1.tag of
          1: begin
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              v8 := canonical_derivative_4(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              v2 := normalize_5(v0);
              v3 := nullable_13(v2);
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
function loop_0(v0: LongInt; v1: TUH0; v2: LongInt; v3: QWord; v4: LongInt): LongInt;
var
  v5: Boolean;
  v6: TUH1;
  v7: TUH1;
  v8: QWord;
  tmp4: TTuple0;
  v9: LongInt;
  v10: Boolean;
  v11: Boolean;
  v13: Boolean;
  v12: Boolean;
  v14: LongInt;
  v16: LongInt;
  v15: LongInt;
  tmp13: LongInt;
  tmp14: TUH0;
  tmp15: LongInt;
  tmp16: QWord;
  tmp17: LongInt;
begin
  while True do begin
      v5 := 0 < v2;
      if v5 then begin
          v6 := UH1_InputEmpty;
          tmp4 := random_bit_input_1(v3, v0, v6);
          v7 := tmp4.f0;
          v8 := tmp4.f1;
          v9 := 0;
          v10 := run_2(v9, v7);
          v11 := accepts_3(v1, v7);
          if v10 then begin
              v13 := v11;
          end else begin
              v12 := False = v11;
              v13 := v12;
          end;
          if v13 then begin
              v14 := v2 - 1;
              if v10 then begin
                  v15 := v4 + 1;
                  v16 := v15;
              end else begin
                  v16 := v4;
              end;
              tmp13 := v0;
              tmp14 := v1;
              tmp15 := v14;
              tmp16 := v8;
              tmp17 := v16;
              v0 := tmp13;
              v1 := tmp14;
              v2 := tmp15;
              v3 := tmp16;
              v4 := tmp17;
              Continue;
          end else begin
              begin WriteLn(StdErr, 'brzozowski-compiled-core-disagrees-on-random-input'); Halt(1); end;
          end;
      end else begin
          Result := v4;
          Exit;
      end;
  end;
end;
function zeros_input_15(v0: LongInt; v1: TUH1): TUH1;
var
  v2: Boolean;
  v3: LongInt;
  v4: TUS0;
  v5: TUH1;
  tmp4: LongInt;
  tmp5: TUH1;
begin
  while True do begin
      v2 := 0 < v0;
      if v2 then begin
          v3 := v0 - 1;
          v4 := US0_BitZero;
          v5 := UH1_InputCons(v4, v1);
          tmp4 := v3;
          tmp5 := v5;
          v0 := tmp4;
          v1 := tmp5;
          Continue;
      end else begin
          Result := v1;
          Exit;
      end;
  end;
end;
function run_16(v0: LongInt; v1: TUH1): Boolean;
var
  v5: TUS0;
  v6: TUH1;
  v7: Boolean;
  v26: LongInt;
  v11: TUS1;
  v12: Boolean;
  v13: Boolean;
  v17: TUS1;
  v18: Boolean;
  v22: TUS1;
  v23: Boolean;
  tmp11: LongInt;
  tmp12: TUH1;
  v2: Boolean;
  v3: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin
              v5 := v1.c1_0;
              v6 := v1.c1_1;
              v7 := v0 = 0;
              if v7 then begin
                  case v5.tag of
                      1: begin
                          v11 := US1_SymbolGreater;
                      end;
                      0: begin
                          v11 := US1_SymbolSame;
                      end;
                  end;
                  case v11.tag of
                      1: begin
                          v12 := True;
                      end;
                      else begin
                          v12 := False;
                      end;
                  end;
                  v26 := 1;
              end else begin
                  v13 := v0 = 1;
                  if v13 then begin
                      case v5.tag of
                          1: begin
                              v17 := US1_SymbolGreater;
                          end;
                          0: begin
                              v17 := US1_SymbolSame;
                          end;
                      end;
                      case v17.tag of
                          1: begin
                              v18 := True;
                          end;
                          else begin
                              v18 := False;
                          end;
                      end;
                      v26 := 1;
                  end else begin
                      case v5.tag of
                          1: begin
                              v22 := US1_SymbolGreater;
                          end;
                          0: begin
                              v22 := US1_SymbolSame;
                          end;
                      end;
                      case v22.tag of
                          1: begin
                              v23 := True;
                          end;
                          else begin
                              v23 := False;
                          end;
                      end;
                      if v23 then begin
                          v26 := 2;
                      end else begin
                          v26 := 0;
                      end;
                  end;
              end;
              tmp11 := v26;
              tmp12 := v6;
              v0 := tmp11;
              v1 := tmp12;
              Continue;
          end;
          0: begin
              v2 := v0 = 0;
              if v2 then begin
                  Result := True;
                  Exit;
              end else begin
                  v3 := v0 = 1;
                  Result := False;
                  Exit;
              end;
          end;
      end;
  end;
end;
function loop_14(v0: LongInt; v1: TUH0; v2: LongInt; v3: LongInt): LongInt;
var
  v4: Boolean;
  v5: TUH1;
  v6: TUH1;
  v7: LongInt;
  v8: Boolean;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
  v15: LongInt;
  v12: LongInt;
  v16: TUS0;
  v17: TUH1;
  v18: TUH1;
  v19: TUH1;
  v20: LongInt;
  v21: Boolean;
  v22: Boolean;
  v24: Boolean;
  v23: Boolean;
  v28: LongInt;
  v25: LongInt;
  v29: LongInt;
  tmp22: LongInt;
  tmp23: TUH0;
  tmp24: LongInt;
  tmp25: LongInt;
begin
  while True do begin
      v4 := v0 < v2;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          v5 := UH1_InputEmpty;
          v6 := zeros_input_15(v2, v5);
          v7 := 2;
          v8 := run_16(v7, v6);
          v9 := accepts_3(v1, v6);
          if v8 then begin
              v11 := v9;
          end else begin
              v10 := False = v9;
              v11 := v10;
          end;
          if v11 then begin
              if v8 then begin
                  v12 := v3 + 1;
                  v15 := v12;
              end else begin
                  v15 := v3;
              end;
          end else begin
              begin WriteLn(StdErr, 'brzozowski-compiled-core-disagrees-on-zero-run'); Halt(1); end;
          end;
          v16 := US0_BitOne;
          v17 := UH1_InputEmpty;
          v18 := UH1_InputCons(v16, v17);
          v19 := zeros_input_15(v2, v18);
          v20 := 2;
          v21 := run_16(v20, v19);
          v22 := accepts_3(v1, v19);
          if v21 then begin
              v24 := v22;
          end else begin
              v23 := False = v22;
              v24 := v23;
          end;
          if v24 then begin
              if v21 then begin
                  v25 := v15 + 1;
                  v28 := v25;
              end else begin
                  v28 := v15;
              end;
          end else begin
              begin WriteLn(StdErr, 'brzozowski-compiled-core-disagrees-on-zero-run'); Halt(1); end;
          end;
          v29 := v2 + 1;
          tmp22 := v0;
          tmp23 := v1;
          tmp24 := v29;
          tmp25 := v28;
          v0 := tmp22;
          v1 := tmp23;
          v2 := tmp24;
          v3 := tmp25;
          Continue;
      end;
  end;
end;
function US3_TriA: TUS3;
begin
  Result.tag := 0; 
end;
function US3_TriB: TUS3;
begin
  Result.tag := 1; 
end;
function US3_TriC: TUS3;
begin
  Result.tag := 2; 
end;
function UH2_RegexEmpty: TUH2;
begin
  Result := TUH2.Create; Result.tag := 0; 
end;
function UH2_RegexEpsilon: TUH2;
begin
  Result := TUH2.Create; Result.tag := 1; 
end;
function UH2_RegexChar(a0: TUS3): TUH2;
begin
  Result := TUH2.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH2_RegexAlt(a0: TUH2; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH2_RegexCat(a0: TUH2; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH2_RegexStar(a0: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function UH3_InputEmpty: TUH3;
begin
  Result := TUH3.Create; Result.tag := 0; 
end;
function UH3_InputCons(a0: TUS3; a1: TUH3): TUH3;
begin
  Result := TUH3.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function run_17(v0: LongInt; v1: TUH3): Boolean;
var
  v5: TUS3;
  v6: TUH3;
  v7: Boolean;
  v47: LongInt;
  v10: TUS1;
  v11: Boolean;
  v17: TUS1;
  v18: Boolean;
  v21: Boolean;
  v24: TUS1;
  v25: Boolean;
  v31: TUS1;
  v32: Boolean;
  v36: TUS1;
  v37: Boolean;
  v43: TUS1;
  v44: Boolean;
  tmp17: LongInt;
  tmp18: TUH3;
  v2: Boolean;
  v3: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin
              v5 := v1.c1_0;
              v6 := v1.c1_1;
              v7 := v0 = 0;
              if v7 then begin
                  case v5.tag of
                      0: begin
                          v10 := US1_SymbolSame;
                      end;
                      else begin
                          v10 := US1_SymbolGreater;
                      end;
                  end;
                  case v10.tag of
                      1: begin
                          v11 := True;
                      end;
                      else begin
                          v11 := False;
                      end;
                  end;
                  if v11 then begin
                      v47 := 0;
                  end else begin
                      case v5.tag of
                          0: begin
                              v17 := US1_SymbolLess;
                          end;
                          1: begin
                              v17 := US1_SymbolSame;
                          end;
                          2: begin
                              v17 := US1_SymbolGreater;
                          end;
                      end;
                      case v17.tag of
                          1: begin
                              v18 := True;
                          end;
                          else begin
                              v18 := False;
                          end;
                      end;
                      if v18 then begin
                          v47 := 0;
                      end else begin
                          v47 := 1;
                      end;
                  end;
              end else begin
                  v21 := v0 = 1;
                  if v21 then begin
                      case v5.tag of
                          0: begin
                              v24 := US1_SymbolSame;
                          end;
                          else begin
                              v24 := US1_SymbolGreater;
                          end;
                      end;
                      case v24.tag of
                          1: begin
                              v25 := True;
                          end;
                          else begin
                              v25 := False;
                          end;
                      end;
                      if v25 then begin
                          v47 := 2;
                      end else begin
                          case v5.tag of
                              0: begin
                                  v31 := US1_SymbolLess;
                              end;
                              1: begin
                                  v31 := US1_SymbolSame;
                              end;
                              2: begin
                                  v31 := US1_SymbolGreater;
                              end;
                          end;
                          case v31.tag of
                              1: begin
                                  v32 := True;
                              end;
                              else begin
                                  v32 := False;
                              end;
                          end;
                          v47 := 2;
                      end;
                  end else begin
                      case v5.tag of
                          0: begin
                              v36 := US1_SymbolSame;
                          end;
                          else begin
                              v36 := US1_SymbolGreater;
                          end;
                      end;
                      case v36.tag of
                          1: begin
                              v37 := True;
                          end;
                          else begin
                              v37 := False;
                          end;
                      end;
                      if v37 then begin
                          v47 := 2;
                      end else begin
                          case v5.tag of
                              0: begin
                                  v43 := US1_SymbolLess;
                              end;
                              1: begin
                                  v43 := US1_SymbolSame;
                              end;
                              2: begin
                                  v43 := US1_SymbolGreater;
                              end;
                          end;
                          case v43.tag of
                              1: begin
                                  v44 := True;
                              end;
                              else begin
                                  v44 := False;
                              end;
                          end;
                          v47 := 2;
                      end;
                  end;
              end;
              tmp17 := v47;
              tmp18 := v6;
              v0 := tmp17;
              v1 := tmp18;
              Continue;
          end;
          0: begin
              v2 := v0 = 0;
              if v2 then begin
                  Result := False;
                  Exit;
              end else begin
                  v3 := v0 = 1;
                  Result := v3;
                  Exit;
              end;
          end;
      end;
  end;
end;
function regex_compare_23(v0: TUH2; v1: TUH2): TUS1;
var
  v59: TUH2;
  v60: TUH2;
  v61: TUH2;
  v62: TUH2;
  v63: TUS1;
  tmp5: TUH2;
  tmp6: TUH2;
  v34: TUH2;
  v35: TUH2;
  v40: TUH2;
  v41: TUH2;
  v42: TUS1;
  tmp12: TUH2;
  tmp13: TUH2;
  v38: TUS3;
  v10: TUS3;
  v13: TUS3;
  v50: TUH2;
  v51: TUH2;
  v52: TUH2;
  v54: TUH2;
  tmp21: TUH2;
  tmp22: TUH2;
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
                      v63 := regex_compare_23(v59, v61);
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
                      Result := US1_SymbolGreater;
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
                      v42 := regex_compare_23(v34, v40);
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
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  0: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  1: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
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
                                      Result := US1_SymbolSame;
                                      Exit;
                                  end;
                                  else begin
                                      Result := US1_SymbolLess;
                                      Exit;
                                  end;
                              end;
                          end;
                          else begin
                              case v13.tag of
                                  0: begin
                                      Result := US1_SymbolGreater;
                                      Exit;
                                  end;
                                  else begin
                                      case v10.tag of
                                          1: begin
                                              case v13.tag of
                                                  1: begin
                                                      Result := US1_SymbolSame;
                                                      Exit;
                                                  end;
                                                  2: begin
                                                      Result := US1_SymbolLess;
                                                      Exit;
                                                  end;
                                              end;
                                          end;
                                          2: begin
                                              case v13.tag of
                                                  1: begin
                                                      Result := US1_SymbolGreater;
                                                      Exit;
                                                  end;
                                                  2: begin
                                                      Result := US1_SymbolSame;
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
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  1: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := US1_SymbolSame;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  0: begin
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
                  1: begin
                      Result := US1_SymbolSame;
                      Exit;
                  end;
                  else begin
                      Result := US1_SymbolLess;
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
                      Result := US1_SymbolLess;
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
                      Result := US1_SymbolGreater;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function alt_insert_sorted_22(v0: TUH2; v1: TUH2): TUH2;
var
  v2: TUH2;
  v3: TUH2;
  v4: TUS1;
  v6: TUH2;
  v11: TUS1;
begin
  case v1.tag of
      3: begin
          v2 := v1.c3_0;
          v3 := v1.c3_1;
          v4 := regex_compare_23(v0, v2);
          case v4.tag of
              2: begin
                  v6 := alt_insert_sorted_22(v0, v3);
                  Result := UH2_RegexAlt(v2, v6);
              end;
              0: begin
                  Result := UH2_RegexAlt(v0, v1);
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
          v11 := regex_compare_23(v0, v1);
          case v11.tag of
              2: begin
                  Result := UH2_RegexAlt(v1, v0);
              end;
              0: begin
                  Result := UH2_RegexAlt(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function make_alt_21(v0: TUH2; v1: TUH2): TUH2;
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
              v4 := alt_insert_sorted_22(v2, v1);
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
              Result := alt_insert_sorted_22(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function regex_equal_25(v0: TUH2; v1: TUH2): Boolean;
var
  v24: TUH2;
  v25: TUH2;
  v26: TUH2;
  v27: TUH2;
  v28: Boolean;
  tmp5: TUH2;
  tmp6: TUH2;
  v32: TUH2;
  v33: TUH2;
  v34: TUH2;
  v35: TUH2;
  v36: Boolean;
  tmp12: TUH2;
  tmp13: TUH2;
  v4: TUS3;
  v5: TUS3;
  v21: TUS1;
  v40: TUH2;
  v41: TUH2;
  tmp19: TUH2;
  tmp20: TUH2;
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
                      v28 := regex_equal_25(v24, v26);
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
                      v36 := regex_equal_25(v32, v34);
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
                                      v21 := US1_SymbolSame;
                                  end;
                                  else begin
                                      v21 := US1_SymbolLess;
                                  end;
                              end;
                          end;
                          else begin
                              case v5.tag of
                                  0: begin
                                      v21 := US1_SymbolGreater;
                                  end;
                                  else begin
                                      case v4.tag of
                                          1: begin
                                              case v5.tag of
                                                  1: begin
                                                      v21 := US1_SymbolSame;
                                                  end;
                                                  2: begin
                                                      v21 := US1_SymbolLess;
                                                  end;
                                              end;
                                          end;
                                          2: begin
                                              case v5.tag of
                                                  1: begin
                                                      v21 := US1_SymbolGreater;
                                                  end;
                                                  2: begin
                                                      v21 := US1_SymbolSame;
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
function make_cat_24(v0: TUH2; v1: TUH2): TUH2;
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
          Result := UH2_RegexEmpty;
      end;
      else begin
          case v1.tag of
              0: begin
                  Result := UH2_RegexEmpty;
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
                                          v14 := make_cat_24(v13, v1);
                                          Result := UH2_RegexCat(v12, v14);
                                      end;
                                      5: begin
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin
                                                  v5 := v1.c5_0;
                                                  v6 := regex_equal_25(v4, v5);
                                                  if v6 then begin
                                                      Result := UH2_RegexStar(v4);
                                                  end else begin
                                                      Result := UH2_RegexCat(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH2_RegexCat(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH2_RegexCat(v0, v1);
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
function make_star_26(v0: TUH2): TUH2;
var
  v3: TUH2;
begin
  case v0.tag of
      0: begin
          Result := UH2_RegexEpsilon;
      end;
      1: begin
          Result := UH2_RegexEpsilon;
      end;
      5: begin
          v3 := v0.c5_0;
          Result := UH2_RegexStar(v3);
      end;
      else begin
          Result := UH2_RegexStar(v0);
      end;
  end;
end;
function normalize_20(v0: TUH2): TUH2;
var
  v5: TUH2;
  v6: TUH2;
  v7: TUH2;
  v8: TUH2;
  v10: TUH2;
  v11: TUH2;
  v12: TUH2;
  v13: TUH2;
  v3: TUS3;
  v15: TUH2;
  v16: TUH2;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := normalize_20(v5);
          v8 := normalize_20(v6);
          Result := make_alt_21(v7, v8);
      end;
      4: begin
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := normalize_20(v10);
          v13 := normalize_20(v11);
          Result := make_cat_24(v12, v13);
      end;
      2: begin
          v3 := v0.c2_0;
          Result := UH2_RegexChar(v3);
      end;
      0: begin
          Result := UH2_RegexEmpty;
      end;
      1: begin
          Result := UH2_RegexEpsilon;
      end;
      5: begin
          v15 := v0.c5_0;
          v16 := normalize_20(v15);
          Result := make_star_26(v16);
      end;
  end;
end;
function nullable_28(v0: TUH2): TUS2;
var
  v5: TUH2;
  v6: TUH2;
  v7: TUS2;
  v8: TUS2;
  v16: TUH2;
  v17: TUH2;
  v18: TUS2;
  v19: TUS2;
  v3: TUS3;
  v25: TUH2;
begin
  case v0.tag of
      3: begin
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := nullable_28(v5);
          v8 := nullable_28(v6);
          case v7.tag of
              0: begin
                  Result := US2_Nullable;
              end;
              else begin
                  case v8.tag of
                      0: begin
                          Result := US2_Nullable;
                      end;
                      else begin
                          case v7.tag of
                              1: begin
                                  case v8.tag of
                                      1: begin
                                          Result := US2_NonNullable;
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
          v18 := nullable_28(v16);
          v19 := nullable_28(v17);
          case v18.tag of
              0: begin
                  case v19.tag of
                      0: begin
                          Result := US2_Nullable;
                      end;
                      else begin
                          Result := US2_NonNullable;
                      end;
                  end;
              end;
              else begin
                  Result := US2_NonNullable;
              end;
          end;
      end;
      2: begin
          v3 := v0.c2_0;
          Result := US2_NonNullable;
      end;
      0: begin
          Result := US2_NonNullable;
      end;
      1: begin
          Result := US2_Nullable;
      end;
      5: begin
          v25 := v0.c5_0;
          Result := US2_Nullable;
      end;
  end;
end;
function derivative_27(v0: TUH2; v1: TUS3): TUH2;
var
  v25: TUH2;
  v26: TUH2;
  v27: TUH2;
  v28: TUH2;
  v30: TUH2;
  v31: TUH2;
  v32: TUS2;
  v37: TUH2;
  v33: TUH2;
  v34: TUH2;
  v35: TUH2;
  v4: TUS3;
  v20: TUS1;
  v21: Boolean;
  v41: TUH2;
  v42: TUH2;
  v43: TUH2;
begin
  case v0.tag of
      3: begin
          v25 := v0.c3_0;
          v26 := v0.c3_1;
          v27 := derivative_27(v25, v1);
          v28 := derivative_27(v26, v1);
          Result := make_alt_21(v27, v28);
      end;
      4: begin
          v30 := v0.c4_0;
          v31 := v0.c4_1;
          v32 := nullable_28(v30);
          case v32.tag of
              1: begin
                  v37 := derivative_27(v30, v1);
                  Result := make_cat_24(v37, v31);
              end;
              0: begin
                  v33 := derivative_27(v30, v1);
                  v34 := make_cat_24(v33, v31);
                  v35 := derivative_27(v31, v1);
                  Result := make_alt_21(v34, v35);
              end;
          end;
      end;
      2: begin
          v4 := v0.c2_0;
          case v4.tag of
              0: begin
                  case v1.tag of
                      0: begin
                          v20 := US1_SymbolSame;
                      end;
                      else begin
                          v20 := US1_SymbolLess;
                      end;
                  end;
              end;
              else begin
                  case v1.tag of
                      0: begin
                          v20 := US1_SymbolGreater;
                      end;
                      else begin
                          case v4.tag of
                              1: begin
                                  case v1.tag of
                                      1: begin
                                          v20 := US1_SymbolSame;
                                      end;
                                      2: begin
                                          v20 := US1_SymbolLess;
                                      end;
                                  end;
                              end;
                              2: begin
                                  case v1.tag of
                                      1: begin
                                          v20 := US1_SymbolGreater;
                                      end;
                                      2: begin
                                          v20 := US1_SymbolSame;
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
              Result := UH2_RegexEpsilon;
          end else begin
              Result := UH2_RegexEmpty;
          end;
      end;
      0: begin
          Result := UH2_RegexEmpty;
      end;
      1: begin
          Result := UH2_RegexEmpty;
      end;
      5: begin
          v41 := v0.c5_0;
          v42 := derivative_27(v41, v1);
          v43 := make_star_26(v41);
          Result := make_cat_24(v42, v43);
      end;
  end;
end;
function canonical_derivative_19(v0: TUH2; v1: TUS3): TUH2;
var
  v2: TUH2;
  v3: TUH2;
begin
  v2 := normalize_20(v0);
  v3 := derivative_27(v2, v1);
  Result := normalize_20(v3);
end;
function accepts_18(v0: TUH2; v1: TUH3): Boolean;
var
  v6: TUS3;
  v7: TUH3;
  v8: TUH2;
  tmp3: TUH2;
  tmp4: TUH3;
  v2: TUH2;
  v3: TUS2;
begin
  while True do begin
      case v1.tag of
          1: begin
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              v8 := canonical_derivative_19(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              v2 := normalize_20(v0);
              v3 := nullable_28(v2);
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
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: TUS0;
  v4: TUH0;
  v5: TUS0;
  v6: TUH0;
  v7: TUH0;
  v8: TUH0;
  v9: TUS0;
  v10: TUH0;
  v11: TUH0;
  v12: QWord;
  v13: LongInt;
  v14: LongInt;
  v15: Boolean;
  v16: TUS0;
  v17: TUH0;
  v18: TUS0;
  v19: TUH0;
  v20: TUS0;
  v21: TUH0;
  v22: TUH0;
  v23: TUH0;
  v24: TUH0;
  v25: TUS0;
  v26: TUH0;
  v27: TUH0;
  v28: LongInt;
  v29: LongInt;
  v30: LongInt;
  v31: Boolean;
  v32: TUS3;
  v33: TUH2;
  v34: TUS3;
  v35: TUH2;
  v36: TUH2;
  v37: TUH2;
  v38: TUS3;
  v39: TUH2;
  v40: TUH2;
  v41: TUS3;
  v42: TUS3;
  v43: TUS3;
  v44: TUS3;
  v45: TUH3;
  v46: TUH3;
  v47: TUH3;
  v48: TUH3;
  v49: TUH3;
  v50: TUS3;
  v51: TUS3;
  v52: TUS3;
  v53: TUS3;
  v54: TUH3;
  v55: TUH3;
  v56: TUH3;
  v57: TUH3;
  v58: TUH3;
  v59: LongInt;
  v60: Boolean;
  v62: Boolean;
  v68: Boolean;
  v63: LongInt;
  v64: Boolean;
  v65: Boolean;
  v66: Boolean;
begin
  v0 := 200;
  v1 := 32;
  v2 := 16;
  v3 := US0_BitZero;
  v4 := UH0_RegexChar(v3);
  v5 := US0_BitOne;
  v6 := UH0_RegexChar(v5);
  v7 := UH0_RegexAlt(v4, v6);
  v8 := UH0_RegexStar(v7);
  v9 := US0_BitZero;
  v10 := UH0_RegexChar(v9);
  v11 := UH0_RegexCat(v8, v10);
  v12 := 1;
  v13 := 0;
  v14 := loop_0(v1, v11, v0, v12, v13);
  v15 := v14 = 93;
  if v15 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-compiled-ends-with-zero-count'); Halt(1); end;
  end;
  v16 := US0_BitZero;
  v17 := UH0_RegexChar(v16);
  v18 := US0_BitZero;
  v19 := UH0_RegexChar(v18);
  v20 := US0_BitZero;
  v21 := UH0_RegexChar(v20);
  v22 := UH0_RegexCat(v19, v21);
  v23 := UH0_RegexAlt(v17, v22);
  v24 := UH0_RegexStar(v23);
  v25 := US0_BitOne;
  v26 := UH0_RegexChar(v25);
  v27 := UH0_RegexCat(v24, v26);
  v28 := 1;
  v29 := 0;
  v30 := loop_14(v2, v27, v28, v29);
  v31 := v30 = 16;
  if v31 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-compiled-zero-runs-count'); Halt(1); end;
  end;
  v32 := US3_TriA;
  v33 := UH2_RegexChar(v32);
  v34 := US3_TriB;
  v35 := UH2_RegexChar(v34);
  v36 := UH2_RegexAlt(v33, v35);
  v37 := UH2_RegexStar(v36);
  v38 := US3_TriC;
  v39 := UH2_RegexChar(v38);
  v40 := UH2_RegexCat(v37, v39);
  v41 := US3_TriA;
  v42 := US3_TriB;
  v43 := US3_TriA;
  v44 := US3_TriC;
  v45 := UH3_InputEmpty;
  v46 := UH3_InputCons(v44, v45);
  v47 := UH3_InputCons(v43, v46);
  v48 := UH3_InputCons(v42, v47);
  v49 := UH3_InputCons(v41, v48);
  v50 := US3_TriA;
  v51 := US3_TriB;
  v52 := US3_TriA;
  v53 := US3_TriB;
  v54 := UH3_InputEmpty;
  v55 := UH3_InputCons(v53, v54);
  v56 := UH3_InputCons(v52, v55);
  v57 := UH3_InputCons(v51, v56);
  v58 := UH3_InputCons(v50, v57);
  v59 := 0;
  v60 := run_17(v59, v49);
  if v60 then begin
      v62 := accepts_18(v40, v49);
  end else begin
      v62 := False;
  end;
  if v62 then begin
      v63 := 0;
      v64 := run_17(v63, v58);
      if v64 then begin
          v68 := False;
      end else begin
          v65 := accepts_18(v40, v58);
          v66 := v65 = False;
          v68 := v66;
      end;
  end else begin
      v68 := False;
  end;
  if v68 then begin
      Result := 0;
  end else begin
      begin WriteLn(StdErr, 'brzozowski-compiled-ternary-disagrees'); Halt(1); end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
