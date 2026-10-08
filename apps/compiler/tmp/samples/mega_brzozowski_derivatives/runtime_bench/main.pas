program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH1 = class;
  TUH2 = class;
  TUS0 = record tag: LongInt;  end;
  TUH0 = class tag: LongInt; c2_0: TUS0; c3_0: TUH0; c3_1: TUH0; c4_0: TUH0; c4_1: TUH0; c5_0: TUH0; end;
  TUH1 = class tag: LongInt; c1_0: TUS0; c1_1: TUH1; end;
  TTuple0 = record f0: TUH1; f1: QWord; end;
  TUS1 = record tag: LongInt;  end;
  TUS2 = record tag: LongInt;  end;
  TUH2 = class tag: LongInt; c1_0: TUH0; c1_1: TUH2; end;
  TArray0 = array of LongInt;
function method1(v0: QWord; v1: LongInt; v2: TUH1): TTuple0; forward;
function method7(v0: TUH0; v1: TUH0): TUS1; forward;
function method6(v0: TUH0; v1: TUH0): TUH0; forward;
function method5(v0: TUH0; v1: TUH0): TUH0; forward;
function method9(v0: TUH0; v1: TUH0): Boolean; forward;
function method8(v0: TUH0; v1: TUH0): TUH0; forward;
function method10(v0: TUH0): TUH0; forward;
function method4(v0: TUH0): TUH0; forward;
function method12(v0: TUH0): TUS2; forward;
function method11(v0: TUH0; v1: TUS0): TUH0; forward;
function method3(v0: TUH0; v1: TUS0): TUH0; forward;
function method2(v0: TUH0; v1: TUH1): Boolean; forward;
function method0(v0: TUH0; v1: LongInt; v2: LongInt; v3: QWord; v4: LongInt): LongInt; forward;
function method14(v0: LongInt; v1: TUH1): TUH1; forward;
function method13(v0: TUH0; v1: LongInt; v2: LongInt; v3: LongInt): LongInt; forward;
function method16(v0: TUH2; v1: TUH1): Boolean; forward;
function method15(v0: TUH0; v1: LongInt; v2: LongInt; v3: QWord; v4: LongInt): LongInt; forward;
function method17(v0: TUH0; v1: LongInt; v2: LongInt; v3: LongInt): LongInt; forward;
function method19(v0: LongInt; v1: TUH1): Boolean; forward;
function method18(v0: LongInt; v1: LongInt; v2: QWord; v3: LongInt): LongInt; forward;
function method21(v0: LongInt; v1: TUH1): Boolean; forward;
function method20(v0: LongInt; v1: LongInt; v2: QWord; v3: LongInt): LongInt; forward;
function method23(v0: LongInt; v1: TUH1): Boolean; forward;
function method22(v0: LongInt; v1: LongInt; v2: LongInt): LongInt; forward;
procedure method24(v0: TArray0; v1: LongInt); forward;
procedure method25(v0: TArray0; v1: LongInt); forward;
function method27(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt; v10: LongInt): LongInt; forward;
function method26(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt): LongInt; forward;
function method30(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt; forward;
function method29(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt; forward;
function method31(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt; forward;
function method28(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: TUH0): LongInt; forward;
function method35(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt; forward;
function method34(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: TUH1): Boolean; forward;
function method33(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: TUH1): Boolean; forward;
function method32(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt; v10: QWord; v11: LongInt): LongInt; forward;
function method36(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt; v10: LongInt): LongInt; forward;
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
function UH0_1: TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; 
end;
function UH0_2(a0: TUS0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH0_3(a0: TUH0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH0_4(a0: TUH0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH0_5(a0: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function UH1_0: TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; 
end;
function UH1_1(a0: TUS0; a1: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function TupleCreate0(f0: TUH1; f1: QWord): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method1(v0: QWord; v1: LongInt; v2: TUH1): TTuple0;
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
              v11 := US0_0;
              v13 := v11;
          end else begin
              v12 := US0_1;
              v13 := v12;
          end;
          v14 := UH1_1(v13, v2);
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
function method7(v0: TUH0; v1: TUH0): TUS1;
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
                      v57 := method7(v53, v55);
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
                      Result := US1_2;
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
                      v36 := method7(v28, v34);
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
                      Result := US1_2;
                      Exit;
                  end;
                  0: begin
                      Result := US1_2;
                      Exit;
                  end;
                  1: begin
                      Result := US1_2;
                      Exit;
                  end;
                  else begin
                      Result := US1_0;
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
                                      Result := US1_1;
                                      Exit;
                                  end;
                                  0: begin
                                      Result := US1_2;
                                      Exit;
                                  end;
                              end;
                          end;
                          0: begin
                              case v13.tag of
                                  1: begin
                                      Result := US1_0;
                                      Exit;
                                  end;
                                  0: begin
                                      Result := US1_1;
                                      Exit;
                                  end;
                              end;
                          end;
                      end;
                  end;
                  0: begin
                      Result := US1_2;
                      Exit;
                  end;
                  1: begin
                      Result := US1_2;
                      Exit;
                  end;
                  else begin
                      Result := US1_0;
                      Exit;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  0: begin
                      Result := US1_1;
                      Exit;
                  end;
                  else begin
                      Result := US1_0;
                      Exit;
                  end;
              end;
          end;
          1: begin
              case v1.tag of
                  0: begin
                      Result := US1_2;
                      Exit;
                  end;
                  1: begin
                      Result := US1_1;
                      Exit;
                  end;
                  else begin
                      Result := US1_0;
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
                      Result := US1_0;
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
                      Result := US1_2;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function method6(v0: TUH0; v1: TUH0): TUH0;
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
          v4 := method7(v0, v2);
          case v4.tag of
              2: begin
                  v6 := method6(v0, v3);
                  Result := UH0_3(v2, v6);
              end;
              0: begin
                  Result := UH0_3(v0, v1);
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
          v11 := method7(v0, v1);
          case v11.tag of
              2: begin
                  Result := UH0_3(v1, v0);
              end;
              0: begin
                  Result := UH0_3(v0, v1);
              end;
              1: begin
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function method5(v0: TUH0; v1: TUH0): TUH0;
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
              v4 := method6(v2, v1);
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
              Result := method6(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function method9(v0: TUH0; v1: TUH0): Boolean;
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
                      v22 := method9(v18, v20);
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
                      v30 := method9(v26, v28);
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
                                      v15 := US1_1;
                                  end;
                                  0: begin
                                      v15 := US1_2;
                                  end;
                              end;
                          end;
                          0: begin
                              case v5.tag of
                                  1: begin
                                      v15 := US1_0;
                                  end;
                                  0: begin
                                      v15 := US1_1;
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
function method8(v0: TUH0; v1: TUH0): TUH0;
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
          Result := UH0_0;
      end;
      else begin
          case v1.tag of
              0: begin
                  Result := UH0_0;
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
                                          v14 := method8(v13, v1);
                                          Result := UH0_4(v12, v14);
                                      end;
                                      5: begin
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin
                                                  v5 := v1.c5_0;
                                                  v6 := method9(v4, v5);
                                                  if v6 then begin
                                                      Result := UH0_5(v4);
                                                  end else begin
                                                      Result := UH0_4(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH0_4(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH0_4(v0, v1);
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
function method10(v0: TUH0): TUH0;
var
  v3: TUH0;
begin
  case v0.tag of
      0: begin
          Result := UH0_1;
      end;
      1: begin
          Result := UH0_1;
      end;
      5: begin
          v3 := v0.c5_0;
          Result := UH0_5(v3);
      end;
      else begin
          Result := UH0_5(v0);
      end;
  end;
end;
function method4(v0: TUH0): TUH0;
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
          v7 := method4(v5);
          v8 := method4(v6);
          Result := method5(v7, v8);
      end;
      4: begin
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := method4(v10);
          v13 := method4(v11);
          Result := method8(v12, v13);
      end;
      2: begin
          v3 := v0.c2_0;
          Result := UH0_2(v3);
      end;
      0: begin
          Result := UH0_0;
      end;
      1: begin
          Result := UH0_1;
      end;
      5: begin
          v15 := v0.c5_0;
          v16 := method4(v15);
          Result := method10(v16);
      end;
  end;
end;
function US2_0: TUS2;
begin
  Result.tag := 0; 
end;
function US2_1: TUS2;
begin
  Result.tag := 1; 
end;
function method12(v0: TUH0): TUS2;
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
          v7 := method12(v5);
          v8 := method12(v6);
          case v7.tag of
              0: begin
                  Result := US2_0;
              end;
              else begin
                  case v8.tag of
                      0: begin
                          Result := US2_0;
                      end;
                      else begin
                          case v7.tag of
                              1: begin
                                  case v8.tag of
                                      1: begin
                                          Result := US2_1;
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
          v18 := method12(v16);
          v19 := method12(v17);
          case v18.tag of
              0: begin
                  case v19.tag of
                      0: begin
                          Result := US2_0;
                      end;
                      else begin
                          Result := US2_1;
                      end;
                  end;
              end;
              else begin
                  Result := US2_1;
              end;
          end;
      end;
      2: begin
          v3 := v0.c2_0;
          Result := US2_1;
      end;
      0: begin
          Result := US2_1;
      end;
      1: begin
          Result := US2_0;
      end;
      5: begin
          v25 := v0.c5_0;
          Result := US2_0;
      end;
  end;
end;
function method11(v0: TUH0; v1: TUS0): TUH0;
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
          v21 := method11(v19, v1);
          v22 := method11(v20, v1);
          Result := method5(v21, v22);
      end;
      4: begin
          v24 := v0.c4_0;
          v25 := v0.c4_1;
          v26 := method12(v24);
          case v26.tag of
              1: begin
                  v31 := method11(v24, v1);
                  Result := method8(v31, v25);
              end;
              0: begin
                  v27 := method11(v24, v1);
                  v28 := method8(v27, v25);
                  v29 := method11(v25, v1);
                  Result := method5(v28, v29);
              end;
          end;
      end;
      2: begin
          v4 := v0.c2_0;
          case v4.tag of
              1: begin
                  case v1.tag of
                      1: begin
                          v14 := US1_1;
                      end;
                      0: begin
                          v14 := US1_2;
                      end;
                  end;
              end;
              0: begin
                  case v1.tag of
                      1: begin
                          v14 := US1_0;
                      end;
                      0: begin
                          v14 := US1_1;
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
              Result := UH0_1;
          end else begin
              Result := UH0_0;
          end;
      end;
      0: begin
          Result := UH0_0;
      end;
      1: begin
          Result := UH0_0;
      end;
      5: begin
          v35 := v0.c5_0;
          v36 := method11(v35, v1);
          v37 := method10(v35);
          Result := method8(v36, v37);
      end;
  end;
end;
function method3(v0: TUH0; v1: TUS0): TUH0;
var
  v2: TUH0;
  v3: TUH0;
begin
  v2 := method4(v0);
  v3 := method11(v2, v1);
  Result := method4(v3);
end;
function method2(v0: TUH0; v1: TUH1): Boolean;
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
              v8 := method3(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin
              v2 := method4(v0);
              v3 := method12(v2);
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
function method0(v0: TUH0; v1: LongInt; v2: LongInt; v3: QWord; v4: LongInt): LongInt;
var
  v5: Boolean;
  v6: TUH1;
  v7: TUH1;
  v8: QWord;
  tmp4: TTuple0;
  v9: Boolean;
  v11: LongInt;
  v10: LongInt;
  v12: LongInt;
  tmp9: TUH0;
  tmp10: LongInt;
  tmp11: LongInt;
  tmp12: QWord;
  tmp13: LongInt;
begin
  while True do begin
      v5 := 0 < v2;
      if v5 then begin
          v6 := UH1_0;
          tmp4 := method1(v3, v1, v6);
          v7 := tmp4.f0;
          v8 := tmp4.f1;
          v9 := method2(v0, v7);
          if v9 then begin
              v10 := v4 + 1;
              v11 := v10;
          end else begin
              v11 := v4;
          end;
          v12 := v2 - 1;
          tmp9 := v0;
          tmp10 := v1;
          tmp11 := v12;
          tmp12 := v8;
          tmp13 := v11;
          v0 := tmp9;
          v1 := tmp10;
          v2 := tmp11;
          v3 := tmp12;
          v4 := tmp13;
          Continue;
      end else begin
          Result := v4;
          Exit;
      end;
  end;
end;
function method14(v0: LongInt; v1: TUH1): TUH1;
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
          v4 := US0_0;
          v5 := UH1_1(v4, v1);
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
function method13(v0: TUH0; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
var
  v4: Boolean;
  v5: TUH1;
  v6: TUH1;
  v7: Boolean;
  v9: LongInt;
  v8: LongInt;
  v10: TUS0;
  v11: TUH1;
  v12: TUH1;
  v13: TUH1;
  v14: Boolean;
  v16: LongInt;
  v15: LongInt;
  v17: LongInt;
  tmp14: TUH0;
  tmp15: LongInt;
  tmp16: LongInt;
  tmp17: LongInt;
begin
  while True do begin
      v4 := v1 < v2;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          v5 := UH1_0;
          v6 := method14(v2, v5);
          v7 := method2(v0, v6);
          if v7 then begin
              v8 := v3 + 1;
              v9 := v8;
          end else begin
              v9 := v3;
          end;
          v10 := US0_1;
          v11 := UH1_0;
          v12 := UH1_1(v10, v11);
          v13 := method14(v2, v12);
          v14 := method2(v0, v13);
          if v14 then begin
              v15 := v9 + 1;
              v16 := v15;
          end else begin
              v16 := v9;
          end;
          v17 := v2 + 1;
          tmp14 := v0;
          tmp15 := v1;
          tmp16 := v17;
          tmp17 := v16;
          v0 := tmp14;
          v1 := tmp15;
          v2 := tmp16;
          v3 := tmp17;
          Continue;
      end;
  end;
end;
function UH2_0: TUH2;
begin
  Result := TUH2.Create; Result.tag := 0; 
end;
function UH2_1(a0: TUH0; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function method16(v0: TUH2; v1: TUH1): Boolean;
var
  v6: TUH0;
  v7: TUH2;
  v27: TUH0;
  v28: TUH0;
  v29: TUH2;
  v30: Boolean;
  v31: TUH2;
  tmp7: TUH2;
  tmp8: TUH1;
  v34: TUH0;
  v35: TUH0;
  v36: TUH2;
  v37: TUH2;
  tmp13: TUH2;
  tmp14: TUH1;
  v9: TUS0;
  v10: TUS0;
  v11: TUH1;
  v21: TUS1;
  v22: Boolean;
  tmp20: TUH2;
  tmp21: TUH1;
  tmp22: TUH2;
  tmp23: TUH1;
  v39: TUH0;
  v40: TUH2;
  v41: Boolean;
  tmp27: TUH2;
  tmp28: TUH1;
  v2: TUS0;
  v3: TUH1;
begin
  while True do begin
      case v0.tag of
          1: begin
              v6 := v0.c1_0;
              v7 := v0.c1_1;
              case v6.tag of
                  3: begin
                      v27 := v6.c3_0;
                      v28 := v6.c3_1;
                      v29 := UH2_1(v27, v7);
                      v30 := method16(v29, v1);
                      if v30 then begin
                          Result := True;
                          Exit;
                      end else begin
                          v31 := UH2_1(v28, v7);
                          tmp7 := v31;
                          tmp8 := v1;
                          v0 := tmp7;
                          v1 := tmp8;
                          Continue;
                      end;
                  end;
                  4: begin
                      v34 := v6.c4_0;
                      v35 := v6.c4_1;
                      v36 := UH2_1(v35, v7);
                      v37 := UH2_1(v34, v36);
                      tmp13 := v37;
                      tmp14 := v1;
                      v0 := tmp13;
                      v1 := tmp14;
                      Continue;
                  end;
                  2: begin
                      v9 := v6.c2_0;
                      case v1.tag of
                          1: begin
                              v10 := v1.c1_0;
                              v11 := v1.c1_1;
                              case v9.tag of
                                  1: begin
                                      case v10.tag of
                                          1: begin
                                              v21 := US1_1;
                                          end;
                                          0: begin
                                              v21 := US1_2;
                                          end;
                                      end;
                                  end;
                                  0: begin
                                      case v10.tag of
                                          1: begin
                                              v21 := US1_0;
                                          end;
                                          0: begin
                                              v21 := US1_1;
                                          end;
                                      end;
                                  end;
                              end;
                              case v21.tag of
                                  1: begin
                                      v22 := True;
                                  end;
                                  else begin
                                      v22 := False;
                                  end;
                              end;
                              if v22 then begin
                                  tmp20 := v7;
                                  tmp21 := v11;
                                  v0 := tmp20;
                                  v1 := tmp21;
                                  Continue;
                              end else begin
                                  Result := False;
                                  Exit;
                              end;
                          end;
                          0: begin
                              Result := False;
                              Exit;
                          end;
                      end;
                  end;
                  0: begin
                      Result := False;
                      Exit;
                  end;
                  1: begin
                      tmp22 := v7;
                      tmp23 := v1;
                      v0 := tmp22;
                      v1 := tmp23;
                      Continue;
                  end;
                  5: begin
                      v39 := v6.c5_0;
                      v40 := UH2_1(v39, v0);
                      v41 := method16(v40, v1);
                      if v41 then begin
                          Result := True;
                          Exit;
                      end else begin
                          tmp27 := v7;
                          tmp28 := v1;
                          v0 := tmp27;
                          v1 := tmp28;
                          Continue;
                      end;
                  end;
              end;
          end;
          0: begin
              case v1.tag of
                  1: begin
                      v2 := v1.c1_0;
                      v3 := v1.c1_1;
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
function method15(v0: TUH0; v1: LongInt; v2: LongInt; v3: QWord; v4: LongInt): LongInt;
var
  v5: Boolean;
  v6: TUH1;
  v7: TUH1;
  v8: QWord;
  tmp4: TTuple0;
  v9: TUH2;
  v10: TUH2;
  v11: Boolean;
  v13: LongInt;
  v12: LongInt;
  v14: LongInt;
  tmp11: TUH0;
  tmp12: LongInt;
  tmp13: LongInt;
  tmp14: QWord;
  tmp15: LongInt;
begin
  while True do begin
      v5 := 0 < v2;
      if v5 then begin
          v6 := UH1_0;
          tmp4 := method1(v3, v1, v6);
          v7 := tmp4.f0;
          v8 := tmp4.f1;
          v9 := UH2_0;
          v10 := UH2_1(v0, v9);
          v11 := method16(v10, v7);
          if v11 then begin
              v12 := v4 + 1;
              v13 := v12;
          end else begin
              v13 := v4;
          end;
          v14 := v2 - 1;
          tmp11 := v0;
          tmp12 := v1;
          tmp13 := v14;
          tmp14 := v8;
          tmp15 := v13;
          v0 := tmp11;
          v1 := tmp12;
          v2 := tmp13;
          v3 := tmp14;
          v4 := tmp15;
          Continue;
      end else begin
          Result := v4;
          Exit;
      end;
  end;
end;
function method17(v0: TUH0; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
var
  v4: Boolean;
  v5: TUH1;
  v6: TUH1;
  v7: TUH2;
  v8: TUH2;
  v9: Boolean;
  v11: LongInt;
  v10: LongInt;
  v12: TUS0;
  v13: TUH1;
  v14: TUH1;
  v15: TUH1;
  v16: TUH2;
  v17: TUH2;
  v18: Boolean;
  v20: LongInt;
  v19: LongInt;
  v21: LongInt;
  tmp18: TUH0;
  tmp19: LongInt;
  tmp20: LongInt;
  tmp21: LongInt;
begin
  while True do begin
      v4 := v1 < v2;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          v5 := UH1_0;
          v6 := method14(v2, v5);
          v7 := UH2_0;
          v8 := UH2_1(v0, v7);
          v9 := method16(v8, v6);
          if v9 then begin
              v10 := v3 + 1;
              v11 := v10;
          end else begin
              v11 := v3;
          end;
          v12 := US0_1;
          v13 := UH1_0;
          v14 := UH1_1(v12, v13);
          v15 := method14(v2, v14);
          v16 := UH2_0;
          v17 := UH2_1(v0, v16);
          v18 := method16(v17, v15);
          if v18 then begin
              v19 := v11 + 1;
              v20 := v19;
          end else begin
              v20 := v11;
          end;
          v21 := v2 + 1;
          tmp18 := v0;
          tmp19 := v1;
          tmp20 := v21;
          tmp21 := v20;
          v0 := tmp18;
          v1 := tmp19;
          v2 := tmp20;
          v3 := tmp21;
          Continue;
      end;
  end;
end;
function method19(v0: LongInt; v1: TUH1): Boolean;
var
  v3: TUS0;
  v4: TUH1;
  v8: Boolean;
  v9: LongInt;
  tmp4: LongInt;
  tmp5: TUH1;
  v5: Boolean;
  v6: LongInt;
  tmp8: LongInt;
  tmp9: TUH1;
  v2: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin
              v3 := v1.c1_0;
              v4 := v1.c1_1;
              case v3.tag of
                  1: begin
                      v8 := v0 = 0;
                      v9 := 0;
                      tmp4 := v9;
                      tmp5 := v4;
                      v0 := tmp4;
                      v1 := tmp5;
                      Continue;
                  end;
                  0: begin
                      v5 := v0 = 0;
                      v6 := 1;
                      tmp8 := v6;
                      tmp9 := v4;
                      v0 := tmp8;
                      v1 := tmp9;
                      Continue;
                  end;
              end;
          end;
          0: begin
              v2 := v0 = 1;
              Result := v2;
              Exit;
          end;
      end;
  end;
end;
function method18(v0: LongInt; v1: LongInt; v2: QWord; v3: LongInt): LongInt;
var
  v4: Boolean;
  v5: TUH1;
  v6: TUH1;
  v7: QWord;
  tmp4: TTuple0;
  v8: LongInt;
  v9: Boolean;
  v11: LongInt;
  v10: LongInt;
  v12: LongInt;
  tmp10: LongInt;
  tmp11: LongInt;
  tmp12: QWord;
  tmp13: LongInt;
begin
  while True do begin
      v4 := 0 < v1;
      if v4 then begin
          v5 := UH1_0;
          tmp4 := method1(v2, v0, v5);
          v6 := tmp4.f0;
          v7 := tmp4.f1;
          v8 := 0;
          v9 := method19(v8, v6);
          if v9 then begin
              v10 := v3 + 1;
              v11 := v10;
          end else begin
              v11 := v3;
          end;
          v12 := v1 - 1;
          tmp10 := v0;
          tmp11 := v12;
          tmp12 := v7;
          tmp13 := v11;
          v0 := tmp10;
          v1 := tmp11;
          v2 := tmp12;
          v3 := tmp13;
          Continue;
      end else begin
          Result := v3;
          Exit;
      end;
  end;
end;
function method21(v0: LongInt; v1: TUH1): Boolean;
var
  v17: TUS0;
  v18: TUH1;
  v50: Boolean;
  v79: LongInt;
  v51: Boolean;
  v52: Boolean;
  v53: Boolean;
  v54: Boolean;
  v55: Boolean;
  v56: Boolean;
  v57: Boolean;
  v58: Boolean;
  v59: Boolean;
  v60: Boolean;
  v61: Boolean;
  v62: Boolean;
  v63: Boolean;
  v64: Boolean;
  tmp18: LongInt;
  tmp19: TUH1;
  v19: Boolean;
  v48: LongInt;
  v20: Boolean;
  v21: Boolean;
  v22: Boolean;
  v23: Boolean;
  v24: Boolean;
  v25: Boolean;
  v26: Boolean;
  v27: Boolean;
  v28: Boolean;
  v29: Boolean;
  v30: Boolean;
  v31: Boolean;
  v32: Boolean;
  v33: Boolean;
  tmp36: LongInt;
  tmp37: TUH1;
  v2: Boolean;
  v3: Boolean;
  v4: Boolean;
  v5: Boolean;
  v6: Boolean;
  v7: Boolean;
  v8: Boolean;
  v9: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin
              v17 := v1.c1_0;
              v18 := v1.c1_1;
              case v17.tag of
                  1: begin
                      v50 := v0 = 0;
                      if v50 then begin
                          v79 := 1;
                      end else begin
                          v51 := v0 = 1;
                          if v51 then begin
                              v79 := 6;
                          end else begin
                              v52 := v0 = 2;
                              if v52 then begin
                                  v79 := 11;
                              end else begin
                                  v53 := v0 = 3;
                                  if v53 then begin
                                      v79 := 5;
                                  end else begin
                                      v54 := v0 = 4;
                                      if v54 then begin
                                          v79 := 1;
                                      end else begin
                                          v55 := v0 = 5;
                                          if v55 then begin
                                              v79 := 6;
                                          end else begin
                                              v56 := v0 = 6;
                                              if v56 then begin
                                                  v79 := 13;
                                              end else begin
                                                  v57 := v0 = 7;
                                                  if v57 then begin
                                                      v79 := 9;
                                                  end else begin
                                                      v58 := v0 = 8;
                                                      if v58 then begin
                                                          v79 := 5;
                                                      end else begin
                                                          v59 := v0 = 9;
                                                          if v59 then begin
                                                              v79 := 12;
                                                          end else begin
                                                              v60 := v0 = 10;
                                                              if v60 then begin
                                                                  v79 := 11;
                                                              end else begin
                                                                  v61 := v0 = 11;
                                                                  if v61 then begin
                                                                      v79 := 12;
                                                                  end else begin
                                                                      v62 := v0 = 12;
                                                                      if v62 then begin
                                                                          v79 := 13;
                                                                      end else begin
                                                                          v63 := v0 = 13;
                                                                          if v63 then begin
                                                                              v79 := 15;
                                                                          end else begin
                                                                              v64 := v0 = 14;
                                                                              if v64 then begin
                                                                                  v79 := 9;
                                                                              end else begin
                                                                                  v79 := 15;
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
                                  end;
                              end;
                          end;
                      end;
                      tmp18 := v79;
                      tmp19 := v18;
                      v0 := tmp18;
                      v1 := tmp19;
                      Continue;
                  end;
                  0: begin
                      v19 := v0 = 0;
                      if v19 then begin
                          v48 := 0;
                      end else begin
                          v20 := v0 = 1;
                          if v20 then begin
                              v48 := 2;
                          end else begin
                              v21 := v0 = 2;
                              if v21 then begin
                                  v48 := 3;
                              end else begin
                                  v22 := v0 = 3;
                                  if v22 then begin
                                      v48 := 4;
                                  end else begin
                                      v23 := v0 = 4;
                                      if v23 then begin
                                          v48 := 0;
                                      end else begin
                                          v24 := v0 = 5;
                                          if v24 then begin
                                              v48 := 2;
                                          end else begin
                                              v25 := v0 = 6;
                                              if v25 then begin
                                                  v48 := 7;
                                              end else begin
                                                  v26 := v0 = 7;
                                                  if v26 then begin
                                                      v48 := 8;
                                                  end else begin
                                                      v27 := v0 = 8;
                                                      if v27 then begin
                                                          v48 := 4;
                                                      end else begin
                                                          v28 := v0 = 9;
                                                          if v28 then begin
                                                              v48 := 10;
                                                          end else begin
                                                              v29 := v0 = 10;
                                                              if v29 then begin
                                                                  v48 := 3;
                                                              end else begin
                                                                  v30 := v0 = 11;
                                                                  if v30 then begin
                                                                      v48 := 10;
                                                                  end else begin
                                                                      v31 := v0 = 12;
                                                                      if v31 then begin
                                                                          v48 := 7;
                                                                      end else begin
                                                                          v32 := v0 = 13;
                                                                          if v32 then begin
                                                                              v48 := 14;
                                                                          end else begin
                                                                              v33 := v0 = 14;
                                                                              if v33 then begin
                                                                                  v48 := 8;
                                                                              end else begin
                                                                                  v48 := 14;
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
                                  end;
                              end;
                          end;
                      end;
                      tmp36 := v48;
                      tmp37 := v18;
                      v0 := tmp36;
                      v1 := tmp37;
                      Continue;
                  end;
              end;
          end;
          0: begin
              v2 := v0 = 4;
              if v2 then begin
                  Result := True;
                  Exit;
              end else begin
                  v3 := v0 = 5;
                  if v3 then begin
                      Result := True;
                      Exit;
                  end else begin
                      v4 := v0 = 8;
                      if v4 then begin
                          Result := True;
                          Exit;
                      end else begin
                          v5 := v0 = 9;
                          if v5 then begin
                              Result := True;
                              Exit;
                          end else begin
                              v6 := v0 = 10;
                              if v6 then begin
                                  Result := True;
                                  Exit;
                              end else begin
                                  v7 := v0 = 12;
                                  if v7 then begin
                                      Result := True;
                                      Exit;
                                  end else begin
                                      v8 := v0 = 14;
                                      if v8 then begin
                                          Result := True;
                                          Exit;
                                      end else begin
                                          v9 := v0 = 15;
                                          Result := v9;
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
  end;
end;
function method20(v0: LongInt; v1: LongInt; v2: QWord; v3: LongInt): LongInt;
var
  v4: Boolean;
  v5: TUH1;
  v6: TUH1;
  v7: QWord;
  tmp4: TTuple0;
  v8: LongInt;
  v9: Boolean;
  v11: LongInt;
  v10: LongInt;
  v12: LongInt;
  tmp10: LongInt;
  tmp11: LongInt;
  tmp12: QWord;
  tmp13: LongInt;
begin
  while True do begin
      v4 := 0 < v1;
      if v4 then begin
          v5 := UH1_0;
          tmp4 := method1(v2, v0, v5);
          v6 := tmp4.f0;
          v7 := tmp4.f1;
          v8 := 0;
          v9 := method21(v8, v6);
          if v9 then begin
              v10 := v3 + 1;
              v11 := v10;
          end else begin
              v11 := v3;
          end;
          v12 := v1 - 1;
          tmp10 := v0;
          tmp11 := v12;
          tmp12 := v7;
          tmp13 := v11;
          v0 := tmp10;
          v1 := tmp11;
          v2 := tmp12;
          v3 := tmp13;
          Continue;
      end else begin
          Result := v3;
          Exit;
      end;
  end;
end;
function method23(v0: LongInt; v1: TUH1): Boolean;
var
  v3: TUS0;
  v4: TUH1;
  v13: Boolean;
  v19: LongInt;
  v14: Boolean;
  v15: Boolean;
  v16: Boolean;
  tmp7: LongInt;
  tmp8: TUH1;
  v5: Boolean;
  v11: LongInt;
  v6: Boolean;
  v7: Boolean;
  v8: Boolean;
  tmp14: LongInt;
  tmp15: TUH1;
  v2: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin
              v3 := v1.c1_0;
              v4 := v1.c1_1;
              case v3.tag of
                  1: begin
                      v13 := v0 = 0;
                      if v13 then begin
                          v19 := 3;
                      end else begin
                          v14 := v0 = 1;
                          if v14 then begin
                              v19 := 3;
                          end else begin
                              v15 := v0 = 2;
                              if v15 then begin
                                  v19 := 3;
                              end else begin
                                  v16 := v0 = 3;
                                  v19 := 4;
                              end;
                          end;
                      end;
                      tmp7 := v19;
                      tmp8 := v4;
                      v0 := tmp7;
                      v1 := tmp8;
                      Continue;
                  end;
                  0: begin
                      v5 := v0 = 0;
                      if v5 then begin
                          v11 := 1;
                      end else begin
                          v6 := v0 = 1;
                          if v6 then begin
                              v11 := 2;
                          end else begin
                              v7 := v0 = 2;
                              if v7 then begin
                                  v11 := 2;
                              end else begin
                                  v8 := v0 = 3;
                                  v11 := 4;
                              end;
                          end;
                      end;
                      tmp14 := v11;
                      tmp15 := v4;
                      v0 := tmp14;
                      v1 := tmp15;
                      Continue;
                  end;
              end;
          end;
          0: begin
              v2 := v0 = 3;
              Result := v2;
              Exit;
          end;
      end;
  end;
end;
function method22(v0: LongInt; v1: LongInt; v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: TUH1;
  v5: TUH1;
  v6: LongInt;
  v7: Boolean;
  v9: LongInt;
  v8: LongInt;
  v10: TUS0;
  v11: TUH1;
  v12: TUH1;
  v13: TUH1;
  v14: LongInt;
  v15: Boolean;
  v17: LongInt;
  v16: LongInt;
  v18: LongInt;
  tmp16: LongInt;
  tmp17: LongInt;
  tmp18: LongInt;
begin
  while True do begin
      v3 := v0 < v1;
      if v3 then begin
          Result := v2;
          Exit;
      end else begin
          v4 := UH1_0;
          v5 := method14(v1, v4);
          v6 := 0;
          v7 := method23(v6, v5);
          if v7 then begin
              v8 := v2 + 1;
              v9 := v8;
          end else begin
              v9 := v2;
          end;
          v10 := US0_1;
          v11 := UH1_0;
          v12 := UH1_1(v10, v11);
          v13 := method14(v1, v12);
          v14 := 0;
          v15 := method23(v14, v13);
          if v15 then begin
              v16 := v9 + 1;
              v17 := v16;
          end else begin
              v17 := v9;
          end;
          v18 := v1 + 1;
          tmp16 := v0;
          tmp17 := v18;
          tmp18 := v17;
          v0 := tmp16;
          v1 := tmp17;
          v2 := tmp18;
          Continue;
      end;
  end;
end;
procedure method24(v0: TArray0; v1: LongInt);
var
  v2: Boolean;
  v3: LongInt;
  tmp2: TArray0;
  tmp3: LongInt;
begin
  while True do begin
      v2 := v1 < 8192;
      if v2 then begin
          v0[v1] := 0;
          v3 := v1 + 1;
          tmp2 := v0;
          tmp3 := v3;
          v0 := tmp2;
          v1 := tmp3;
          Continue;
      end else begin
          Exit;
      end;
  end;
end;
procedure method25(v0: TArray0; v1: LongInt);
var
  v2: Boolean;
  v3: LongInt;
  tmp2: TArray0;
  tmp3: LongInt;
begin
  while True do begin
      v2 := v1 < 1;
      if v2 then begin
          v0[v1] := 0;
          v3 := v1 + 1;
          tmp2 := v0;
          tmp3 := v3;
          v0 := tmp2;
          v1 := tmp3;
          Continue;
      end else begin
          Exit;
      end;
  end;
end;
function method27(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt; v10: LongInt): LongInt;
var
  v11: LongInt;
  v12: Boolean;
  v13: LongInt;
  v14: Boolean;
  v15: Boolean;
  v32: Boolean;
  v16: Boolean;
  v17: Boolean;
  v18: LongInt;
  v19: Boolean;
  v20: LongInt;
  v21: Boolean;
  v23: Boolean;
  v24: LongInt;
  v25: Boolean;
  v26: LongInt;
  v27: Boolean;
  v33: LongInt;
  v34: LongInt;
  v37: LongInt;
  v38: LongInt;
  v39: Boolean;
  v42: Boolean;
  v40: LongInt;
  v41: Boolean;
  v45: Boolean;
  v43: LongInt;
  v44: Boolean;
  v46: LongInt;
  v47: LongInt;
  tmp30: TArray0;
  tmp31: TArray0;
  tmp32: TArray0;
  tmp33: TArray0;
  tmp34: TArray0;
  tmp35: TArray0;
  tmp36: TArray0;
  tmp37: LongInt;
  tmp38: LongInt;
  tmp39: LongInt;
  tmp40: LongInt;
begin
  while True do begin
      v11 := v4[v10];
      v12 := v11 = 0;
      if v12 then begin
          v13 := v6[0];
          v14 := v13 < 4096;
          if v14 then begin
              v0[v13] := v7;
              v1[v13] := v8;
              v2[v13] := v9;
              v15 := v7 = 1;
              if v15 then begin
                  v32 := True;
              end else begin
                  v16 := v7 = 5;
                  if v16 then begin
                      v32 := True;
                  end else begin
                      v17 := v7 = 3;
                      if v17 then begin
                          v18 := v3[v8];
                          v19 := v18 = 1;
                          if v19 then begin
                              v32 := True;
                          end else begin
                              v20 := v3[v9];
                              v21 := v20 = 1;
                              v32 := v21;
                          end;
                      end else begin
                          v23 := v7 = 4;
                          if v23 then begin
                              v24 := v3[v8];
                              v25 := v24 = 1;
                              if v25 then begin
                                  v26 := v3[v9];
                                  v27 := v26 = 1;
                                  v32 := v27;
                              end else begin
                                  v32 := False;
                              end;
                          end else begin
                              v32 := False;
                          end;
                      end;
                  end;
              end;
              if v32 then begin
                  v33 := 1;
              end else begin
                  v33 := 0;
              end;
              v3[v13] := v33;
              v34 := v13 + 1;
              v4[v10] := v34;
              v6[0] := v34;
              Result := v13;
              Exit;
          end else begin
              begin WriteLn(StdErr, 'brzozowski-interned-store-full'); Halt(1); end;
          end;
      end else begin
          v37 := v11 - 1;
          v38 := v0[v37];
          v39 := v38 = v7;
          if v39 then begin
              v40 := v1[v37];
              v41 := v40 = v8;
              v42 := v41;
          end else begin
              v42 := False;
          end;
          if v42 then begin
              v43 := v2[v37];
              v44 := v43 = v9;
              v45 := v44;
          end else begin
              v45 := False;
          end;
          if v45 then begin
              Result := v37;
              Exit;
          end else begin
              v46 := v10 + 1;
              v47 := v46 and 8191;
              tmp30 := v0;
              tmp31 := v1;
              tmp32 := v2;
              tmp33 := v3;
              tmp34 := v4;
              tmp35 := v5;
              tmp36 := v6;
              tmp37 := v7;
              tmp38 := v8;
              tmp39 := v9;
              tmp40 := v47;
              v0 := tmp30;
              v1 := tmp31;
              v2 := tmp32;
              v3 := tmp33;
              v4 := tmp34;
              v5 := tmp35;
              v6 := tmp36;
              v7 := tmp37;
              v8 := tmp38;
              v9 := tmp39;
              v10 := tmp40;
              Continue;
          end;
      end;
  end;
end;
function method26(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt): LongInt;
var
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
begin
  v10 := v7 * 1024;
  v11 := v10 + v8;
  v12 := v11 * 4099;
  v13 := v12 + v9;
  v14 := v13 and 8191;
  Result := method27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
end;
function method30(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt;
var
  v9: Boolean;
  v10: LongInt;
  v11: Boolean;
  v12: LongInt;
  v13: Boolean;
  v14: LongInt;
  v16: Boolean;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v23: Boolean;
  v24: LongInt;
  v26: Boolean;
  v27: LongInt;
begin
  v9 := v8 = 0;
  if v9 then begin
      Result := v7;
  end else begin
      v10 := v0[v8];
      v11 := v10 = 3;
      if v11 then begin
          v12 := v1[v8];
          v13 := v7 < v12;
          if v13 then begin
              v14 := 3;
              Result := method26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
          end else begin
              v16 := v7 = v12;
              if v16 then begin
                  Result := v8;
              end else begin
                  v17 := 3;
                  v18 := v2[v8];
                  v19 := method30(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                  Result := method26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
              end;
          end;
      end else begin
          v23 := v7 < v8;
          if v23 then begin
              v24 := 3;
              Result := method26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
          end else begin
              v26 := v7 = v8;
              if v26 then begin
                  Result := v8;
              end else begin
                  v27 := 3;
                  Result := method26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
              end;
          end;
      end;
  end;
end;
function method29(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt;
var
  v9: Boolean;
  v10: LongInt;
  v11: Boolean;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
  tmp6: TArray0;
  tmp7: TArray0;
  tmp8: TArray0;
  tmp9: TArray0;
  tmp10: TArray0;
  tmp11: TArray0;
  tmp12: TArray0;
  tmp13: LongInt;
  tmp14: LongInt;
begin
  while True do begin
      v9 := v7 = 0;
      if v9 then begin
          Result := v8;
          Exit;
      end else begin
          v10 := v0[v7];
          v11 := v10 = 3;
          if v11 then begin
              v12 := v2[v7];
              v13 := v1[v7];
              v14 := method30(v0, v1, v2, v3, v4, v5, v6, v13, v8);
              tmp6 := v0;
              tmp7 := v1;
              tmp8 := v2;
              tmp9 := v3;
              tmp10 := v4;
              tmp11 := v5;
              tmp12 := v6;
              tmp13 := v12;
              tmp14 := v14;
              v0 := tmp6;
              v1 := tmp7;
              v2 := tmp8;
              v3 := tmp9;
              v4 := tmp10;
              v5 := tmp11;
              v6 := tmp12;
              v7 := tmp13;
              v8 := tmp14;
              Continue;
          end else begin
              Result := method30(v0, v1, v2, v3, v4, v5, v6, v7, v8);
              Exit;
          end;
      end;
  end;
end;
function method31(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt;
var
  v9: Boolean;
  v10: Boolean;
  v11: Boolean;
  v12: Boolean;
  v13: LongInt;
  v14: Boolean;
  v17: Boolean;
  v15: LongInt;
  v16: Boolean;
  v18: LongInt;
  v19: LongInt;
  v20: Boolean;
  v21: LongInt;
  v24: LongInt;
  v25: Boolean;
  v26: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v31: LongInt;
begin
  v9 := v7 = 0;
  if v9 then begin
      Result := 0;
  end else begin
      v10 := v8 = 0;
      if v10 then begin
          Result := 0;
      end else begin
          v11 := v7 = 1;
          if v11 then begin
              Result := v8;
          end else begin
              v12 := v8 = 1;
              if v12 then begin
                  Result := v7;
              end else begin
                  v13 := v0[v7];
                  v14 := v13 = 5;
                  if v14 then begin
                      v15 := v0[v8];
                      v16 := v15 = 5;
                      v17 := v16;
                  end else begin
                      v17 := False;
                  end;
                  if v17 then begin
                      v18 := v1[v7];
                      v19 := v1[v8];
                      v20 := v18 = v19;
                      if v20 then begin
                          Result := v7;
                      end else begin
                          v21 := 4;
                          Result := method26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
                      end;
                  end else begin
                      v24 := v0[v7];
                      v25 := v24 = 4;
                      if v25 then begin
                          v26 := 4;
                          v27 := v1[v7];
                          v28 := v2[v7];
                          v29 := method31(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                          Result := method26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                      end else begin
                          v31 := 4;
                          Result := method26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                      end;
                  end;
              end;
          end;
      end;
  end;
end;
function method28(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: TUH0): LongInt;
var
  v14: TUH0;
  v15: TUH0;
  v16: LongInt;
  v17: LongInt;
  v19: TUH0;
  v20: TUH0;
  v21: LongInt;
  v22: LongInt;
  v8: TUS0;
  v9: LongInt;
  v11: LongInt;
  v12: LongInt;
  v24: TUH0;
  v25: LongInt;
  v26: LongInt;
  v27: Boolean;
  v28: Boolean;
  v29: LongInt;
  v30: LongInt;
begin
  case v7.tag of
      3: begin
          v14 := v7.c3_0;
          v15 := v7.c3_1;
          v16 := method28(v0, v1, v2, v3, v4, v5, v6, v14);
          v17 := method28(v0, v1, v2, v3, v4, v5, v6, v15);
          Result := method29(v0, v1, v2, v3, v4, v5, v6, v16, v17);
      end;
      4: begin
          v19 := v7.c4_0;
          v20 := v7.c4_1;
          v21 := method28(v0, v1, v2, v3, v4, v5, v6, v19);
          v22 := method28(v0, v1, v2, v3, v4, v5, v6, v20);
          Result := method31(v0, v1, v2, v3, v4, v5, v6, v21, v22);
      end;
      2: begin
          v8 := v7.c2_0;
          v9 := 2;
          case v8.tag of
              1: begin
                  v11 := 1;
              end;
              0: begin
                  v11 := 0;
              end;
          end;
          v12 := 0;
          Result := method26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
      end;
      0: begin
          Result := 0;
      end;
      1: begin
          Result := 1;
      end;
      5: begin
          v24 := v7.c5_0;
          v25 := method28(v0, v1, v2, v3, v4, v5, v6, v24);
          v26 := v0[v25];
          v27 := v26 < 2;
          if v27 then begin
              Result := 1;
          end else begin
              v28 := v26 = 5;
              if v28 then begin
                  Result := v25;
              end else begin
                  v29 := 5;
                  v30 := 0;
                  Result := method26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
              end;
          end;
      end;
  end;
end;
function method35(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt): LongInt;
var
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: Boolean;
  v13: LongInt;
  v14: Boolean;
  v41: LongInt;
  v15: Boolean;
  v16: LongInt;
  v17: Boolean;
  v19: Boolean;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v23: LongInt;
  v25: Boolean;
  v26: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v30: LongInt;
  v31: Boolean;
  v32: LongInt;
  v35: LongInt;
  v36: LongInt;
  v42: LongInt;
  v43: LongInt;
begin
  v9 := v7 * 2;
  v10 := v9 + v8;
  v11 := v5[v10];
  v12 := v11 = 0;
  if v12 then begin
      v13 := v0[v7];
      v14 := v13 < 2;
      if v14 then begin
          v41 := 0;
      end else begin
          v15 := v13 = 2;
          if v15 then begin
              v16 := v1[v7];
              v17 := v16 = v8;
              if v17 then begin
                  v41 := 1;
              end else begin
                  v41 := 0;
              end;
          end else begin
              v19 := v13 = 3;
              if v19 then begin
                  v20 := v1[v7];
                  v21 := method35(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                  v22 := v2[v7];
                  v23 := method35(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                  v41 := method29(v0, v1, v2, v3, v4, v5, v6, v21, v23);
              end else begin
                  v25 := v13 = 4;
                  if v25 then begin
                      v26 := v1[v7];
                      v27 := v2[v7];
                      v28 := method35(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                      v29 := method31(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                      v30 := v3[v26];
                      v31 := v30 = 1;
                      if v31 then begin
                          v32 := method35(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                          v41 := method29(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                      end else begin
                          v41 := v29;
                      end;
                  end else begin
                      v35 := v1[v7];
                      v36 := method35(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                      v41 := method31(v0, v1, v2, v3, v4, v5, v6, v36, v7);
                  end;
              end;
          end;
      end;
      v42 := v41 + 1;
      v5[v10] := v42;
      Result := v41;
  end else begin
      v43 := v11 - 1;
      Result := v43;
  end;
end;
function method34(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: TUH1): Boolean;
var
  v9: Boolean;
  v12: TUS0;
  v13: TUH1;
  v15: LongInt;
  v16: LongInt;
  tmp5: TArray0;
  tmp6: TArray0;
  tmp7: TArray0;
  tmp8: TArray0;
  tmp9: TArray0;
  tmp10: TArray0;
  tmp11: TArray0;
  tmp12: LongInt;
  tmp13: TUH1;
  v10: LongInt;
  v11: Boolean;
begin
  while True do begin
      v9 := v7 = 0;
      if v9 then begin
          Result := False;
          Exit;
      end else begin
          case v8.tag of
              1: begin
                  v12 := v8.c1_0;
                  v13 := v8.c1_1;
                  case v12.tag of
                      1: begin
                          v15 := 1;
                      end;
                      0: begin
                          v15 := 0;
                      end;
                  end;
                  v16 := method35(v0, v1, v2, v3, v4, v5, v6, v7, v15);
                  tmp5 := v0;
                  tmp6 := v1;
                  tmp7 := v2;
                  tmp8 := v3;
                  tmp9 := v4;
                  tmp10 := v5;
                  tmp11 := v6;
                  tmp12 := v16;
                  tmp13 := v13;
                  v0 := tmp5;
                  v1 := tmp6;
                  v2 := tmp7;
                  v3 := tmp8;
                  v4 := tmp9;
                  v5 := tmp10;
                  v6 := tmp11;
                  v7 := tmp12;
                  v8 := tmp13;
                  Continue;
              end;
              0: begin
                  v10 := v3[v7];
                  v11 := v10 = 1;
                  Result := v11;
                  Exit;
              end;
          end;
      end;
  end;
end;
function method33(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: TUH1): Boolean;
begin
  Result := method34(v0, v1, v2, v3, v4, v5, v6, v7, v8);
end;
function method32(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt; v10: QWord; v11: LongInt): LongInt;
var
  v12: Boolean;
  v13: TUH1;
  v14: TUH1;
  v15: QWord;
  tmp4: TTuple0;
  v16: Boolean;
  v18: LongInt;
  v17: LongInt;
  v19: LongInt;
  tmp9: TArray0;
  tmp10: TArray0;
  tmp11: TArray0;
  tmp12: TArray0;
  tmp13: TArray0;
  tmp14: TArray0;
  tmp15: TArray0;
  tmp16: LongInt;
  tmp17: LongInt;
  tmp18: LongInt;
  tmp19: QWord;
  tmp20: LongInt;
begin
  while True do begin
      v12 := 0 < v9;
      if v12 then begin
          v13 := UH1_0;
          tmp4 := method1(v10, v7, v13);
          v14 := tmp4.f0;
          v15 := tmp4.f1;
          v16 := method33(v0, v1, v2, v3, v4, v5, v6, v8, v14);
          if v16 then begin
              v17 := v11 + 1;
              v18 := v17;
          end else begin
              v18 := v11;
          end;
          v19 := v9 - 1;
          tmp9 := v0;
          tmp10 := v1;
          tmp11 := v2;
          tmp12 := v3;
          tmp13 := v4;
          tmp14 := v5;
          tmp15 := v6;
          tmp16 := v7;
          tmp17 := v8;
          tmp18 := v19;
          tmp19 := v15;
          tmp20 := v18;
          v0 := tmp9;
          v1 := tmp10;
          v2 := tmp11;
          v3 := tmp12;
          v4 := tmp13;
          v5 := tmp14;
          v6 := tmp15;
          v7 := tmp16;
          v8 := tmp17;
          v9 := tmp18;
          v10 := tmp19;
          v11 := tmp20;
          Continue;
      end else begin
          Result := v11;
          Exit;
      end;
  end;
end;
function method36(v0: TArray0; v1: TArray0; v2: TArray0; v3: TArray0; v4: TArray0; v5: TArray0; v6: TArray0; v7: LongInt; v8: LongInt; v9: LongInt; v10: LongInt): LongInt;
var
  v11: Boolean;
  v12: TUH1;
  v13: TUH1;
  v14: Boolean;
  v16: LongInt;
  v15: LongInt;
  v17: TUS0;
  v18: TUH1;
  v19: TUH1;
  v20: TUH1;
  v21: Boolean;
  v23: LongInt;
  v22: LongInt;
  v24: LongInt;
  tmp14: TArray0;
  tmp15: TArray0;
  tmp16: TArray0;
  tmp17: TArray0;
  tmp18: TArray0;
  tmp19: TArray0;
  tmp20: TArray0;
  tmp21: LongInt;
  tmp22: LongInt;
  tmp23: LongInt;
  tmp24: LongInt;
begin
  while True do begin
      v11 := v7 < v9;
      if v11 then begin
          Result := v10;
          Exit;
      end else begin
          v12 := UH1_0;
          v13 := method14(v9, v12);
          v14 := method33(v0, v1, v2, v3, v4, v5, v6, v8, v13);
          if v14 then begin
              v15 := v10 + 1;
              v16 := v15;
          end else begin
              v16 := v10;
          end;
          v17 := US0_1;
          v18 := UH1_0;
          v19 := UH1_1(v17, v18);
          v20 := method14(v9, v19);
          v21 := method33(v0, v1, v2, v3, v4, v5, v6, v8, v20);
          if v21 then begin
              v22 := v16 + 1;
              v23 := v22;
          end else begin
              v23 := v16;
          end;
          v24 := v9 + 1;
          tmp14 := v0;
          tmp15 := v1;
          tmp16 := v2;
          tmp17 := v3;
          tmp18 := v4;
          tmp19 := v5;
          tmp20 := v6;
          tmp21 := v7;
          tmp22 := v8;
          tmp23 := v24;
          tmp24 := v23;
          v0 := tmp14;
          v1 := tmp15;
          v2 := tmp16;
          v3 := tmp17;
          v4 := tmp18;
          v5 := tmp19;
          v6 := tmp20;
          v7 := tmp21;
          v8 := tmp22;
          v9 := tmp23;
          v10 := tmp24;
          Continue;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TUS0;
  v3: TUH0;
  v4: TUS0;
  v5: TUH0;
  v6: TUH0;
  v7: TUH0;
  v8: TUS0;
  v9: TUH0;
  v10: TUH0;
  v11: TUS0;
  v12: TUH0;
  v13: TUS0;
  v14: TUH0;
  v15: TUH0;
  v16: TUH0;
  v17: TUS0;
  v18: TUH0;
  v19: TUS0;
  v20: TUH0;
  v21: TUS0;
  v22: TUH0;
  v23: TUH0;
  v24: TUS0;
  v25: TUH0;
  v26: TUS0;
  v27: TUH0;
  v28: TUH0;
  v29: TUS0;
  v30: TUH0;
  v31: TUS0;
  v32: TUH0;
  v33: TUH0;
  v34: TUH0;
  v35: TUH0;
  v36: TUH0;
  v37: TUH0;
  v38: QWord;
  v39: LongInt;
  v40: LongInt;
  v41: LongInt;
  v42: LongInt;
  v43: TUS0;
  v44: TUH0;
  v45: TUS0;
  v46: TUH0;
  v47: TUS0;
  v48: TUH0;
  v49: TUH0;
  v50: TUH0;
  v51: TUH0;
  v52: TUS0;
  v53: TUH0;
  v54: TUH0;
  v55: LongInt;
  v56: LongInt;
  v57: LongInt;
  v58: LongInt;
  v59: LongInt;
  v60: TUS0;
  v61: TUH0;
  v62: TUS0;
  v63: TUH0;
  v64: TUH0;
  v65: TUH0;
  v66: TUS0;
  v67: TUH0;
  v68: TUH0;
  v69: TUS0;
  v70: TUH0;
  v71: TUS0;
  v72: TUH0;
  v73: TUH0;
  v74: TUH0;
  v75: TUS0;
  v76: TUH0;
  v77: TUS0;
  v78: TUH0;
  v79: TUS0;
  v80: TUH0;
  v81: TUH0;
  v82: TUS0;
  v83: TUH0;
  v84: TUS0;
  v85: TUH0;
  v86: TUH0;
  v87: TUS0;
  v88: TUH0;
  v89: TUS0;
  v90: TUH0;
  v91: TUH0;
  v92: TUH0;
  v93: TUH0;
  v94: TUH0;
  v95: TUH0;
  v96: QWord;
  v97: LongInt;
  v98: LongInt;
  v99: LongInt;
  v100: LongInt;
  v101: TUS0;
  v102: TUH0;
  v103: TUS0;
  v104: TUH0;
  v105: TUS0;
  v106: TUH0;
  v107: TUH0;
  v108: TUH0;
  v109: TUH0;
  v110: TUS0;
  v111: TUH0;
  v112: TUH0;
  v113: LongInt;
  v114: LongInt;
  v115: LongInt;
  v116: Boolean;
  v118: Boolean;
  v117: Boolean;
  v120: Boolean;
  v119: Boolean;
  v121: LongInt;
  v122: LongInt;
  v123: QWord;
  v124: LongInt;
  v125: LongInt;
  v126: LongInt;
  v127: LongInt;
  v128: LongInt;
  v129: LongInt;
  v130: LongInt;
  v131: Boolean;
  v133: Boolean;
  v132: Boolean;
  v135: Boolean;
  v134: Boolean;
  v136: LongInt;
  v137: LongInt;
  v138: TArray0;
  tmp139: TArray0;
  v139: TArray0;
  tmp141: TArray0;
  v140: TArray0;
  tmp143: TArray0;
  v141: TArray0;
  tmp145: TArray0;
  v142: TArray0;
  tmp147: TArray0;
  v143: TArray0;
  tmp149: TArray0;
  v144: TArray0;
  tmp151: TArray0;
  v145: LongInt;
  v146: LongInt;
  v147: LongInt;
  v148: LongInt;
  v149: LongInt;
  v150: LongInt;
  v151: LongInt;
  v152: LongInt;
  v153: LongInt;
  v154: LongInt;
  v155: LongInt;
  v156: Boolean;
  v158: Boolean;
  v157: Boolean;
  v166: TArray0;
  v167: TArray0;
  v168: TArray0;
  v169: TArray0;
  v170: TArray0;
  v171: TArray0;
  v172: TArray0;
  v173: TUS0;
  v174: TUH0;
  v175: TUS0;
  v176: TUH0;
  v177: TUH0;
  v178: TUH0;
  v179: TUS0;
  v180: TUH0;
  v181: TUH0;
  v182: LongInt;
  v183: QWord;
  v184: LongInt;
  v185: LongInt;
  v186: TUS0;
  v187: TUH0;
  v188: TUS0;
  v189: TUH0;
  v190: TUH0;
  v191: TUH0;
  v192: TUS0;
  v193: TUH0;
  v194: TUS0;
  v195: TUH0;
  v196: TUS0;
  v197: TUH0;
  v198: TUH0;
  v199: TUS0;
  v200: TUH0;
  v201: TUS0;
  v202: TUH0;
  v203: TUH0;
  v204: TUS0;
  v205: TUH0;
  v206: TUS0;
  v207: TUH0;
  v208: TUH0;
  v209: TUH0;
  v210: TUH0;
  v211: TUH0;
  v212: TUH0;
  v213: LongInt;
  v214: QWord;
  v215: LongInt;
  v216: LongInt;
  v217: LongInt;
  v218: TArray0;
  tmp219: TArray0;
  v219: TArray0;
  tmp221: TArray0;
  v220: TArray0;
  tmp223: TArray0;
  v221: TArray0;
  tmp225: TArray0;
  v222: TArray0;
  tmp227: TArray0;
  v223: TArray0;
  tmp229: TArray0;
  v224: TArray0;
  tmp231: TArray0;
  v225: LongInt;
  v226: LongInt;
  v227: LongInt;
  v228: LongInt;
  v229: LongInt;
  v230: LongInt;
  v231: LongInt;
  v232: LongInt;
  v233: LongInt;
  v234: LongInt;
  v235: LongInt;
  v236: Boolean;
  v238: Boolean;
  v237: Boolean;
  v246: TArray0;
  v247: TArray0;
  v248: TArray0;
  v249: TArray0;
  v250: TArray0;
  v251: TArray0;
  v252: TArray0;
  v253: TUS0;
  v254: TUH0;
  v255: TUS0;
  v256: TUH0;
  v257: TUS0;
  v258: TUH0;
  v259: TUH0;
  v260: TUH0;
  v261: TUH0;
  v262: TUS0;
  v263: TUH0;
  v264: TUH0;
  v265: LongInt;
  v266: LongInt;
  v267: LongInt;
  v268: LongInt;
  v269: Boolean;
  v271: Boolean;
  v270: Boolean;
  v273: Boolean;
  v272: Boolean;
  v274: Boolean;
  v275: Boolean;
  v276: Boolean;
begin
  v0 := 200;
  v1 := 32;
  v2 := US0_0;
  v3 := UH0_2(v2);
  v4 := US0_1;
  v5 := UH0_2(v4);
  v6 := UH0_3(v3, v5);
  v7 := UH0_5(v6);
  v8 := US0_0;
  v9 := UH0_2(v8);
  v10 := UH0_4(v7, v9);
  v11 := US0_0;
  v12 := UH0_2(v11);
  v13 := US0_1;
  v14 := UH0_2(v13);
  v15 := UH0_3(v12, v14);
  v16 := UH0_5(v15);
  v17 := US0_1;
  v18 := UH0_2(v17);
  v19 := US0_0;
  v20 := UH0_2(v19);
  v21 := US0_1;
  v22 := UH0_2(v21);
  v23 := UH0_3(v20, v22);
  v24 := US0_0;
  v25 := UH0_2(v24);
  v26 := US0_1;
  v27 := UH0_2(v26);
  v28 := UH0_3(v25, v27);
  v29 := US0_0;
  v30 := UH0_2(v29);
  v31 := US0_1;
  v32 := UH0_2(v31);
  v33 := UH0_3(v30, v32);
  v34 := UH0_4(v28, v33);
  v35 := UH0_4(v23, v34);
  v36 := UH0_4(v18, v35);
  v37 := UH0_4(v16, v36);
  v38 := 1;
  v39 := 0;
  v40 := method0(v10, v1, v0, v38, v39);
  v41 := method0(v37, v1, v0, v38, v39);
  v42 := 16;
  v43 := US0_0;
  v44 := UH0_2(v43);
  v45 := US0_0;
  v46 := UH0_2(v45);
  v47 := US0_0;
  v48 := UH0_2(v47);
  v49 := UH0_4(v46, v48);
  v50 := UH0_3(v44, v49);
  v51 := UH0_5(v50);
  v52 := US0_1;
  v53 := UH0_2(v52);
  v54 := UH0_4(v51, v53);
  v55 := 0;
  v56 := 1;
  v57 := method13(v54, v42, v56, v55);
  v58 := 200;
  v59 := 32;
  v60 := US0_0;
  v61 := UH0_2(v60);
  v62 := US0_1;
  v63 := UH0_2(v62);
  v64 := UH0_3(v61, v63);
  v65 := UH0_5(v64);
  v66 := US0_0;
  v67 := UH0_2(v66);
  v68 := UH0_4(v65, v67);
  v69 := US0_0;
  v70 := UH0_2(v69);
  v71 := US0_1;
  v72 := UH0_2(v71);
  v73 := UH0_3(v70, v72);
  v74 := UH0_5(v73);
  v75 := US0_1;
  v76 := UH0_2(v75);
  v77 := US0_0;
  v78 := UH0_2(v77);
  v79 := US0_1;
  v80 := UH0_2(v79);
  v81 := UH0_3(v78, v80);
  v82 := US0_0;
  v83 := UH0_2(v82);
  v84 := US0_1;
  v85 := UH0_2(v84);
  v86 := UH0_3(v83, v85);
  v87 := US0_0;
  v88 := UH0_2(v87);
  v89 := US0_1;
  v90 := UH0_2(v89);
  v91 := UH0_3(v88, v90);
  v92 := UH0_4(v86, v91);
  v93 := UH0_4(v81, v92);
  v94 := UH0_4(v76, v93);
  v95 := UH0_4(v74, v94);
  v96 := 1;
  v97 := 0;
  v98 := method15(v68, v59, v58, v96, v97);
  v99 := method15(v95, v59, v58, v96, v97);
  v100 := 16;
  v101 := US0_0;
  v102 := UH0_2(v101);
  v103 := US0_0;
  v104 := UH0_2(v103);
  v105 := US0_0;
  v106 := UH0_2(v105);
  v107 := UH0_4(v104, v106);
  v108 := UH0_3(v102, v107);
  v109 := UH0_5(v108);
  v110 := US0_1;
  v111 := UH0_2(v110);
  v112 := UH0_4(v109, v111);
  v113 := 0;
  v114 := 1;
  v115 := method17(v112, v100, v114, v113);
  v116 := v40 = v98;
  if v116 then begin
      v117 := v41 = v99;
      v118 := v117;
  end else begin
      v118 := False;
  end;
  if v118 then begin
      v119 := v57 = v115;
      v120 := v119;
  end else begin
      v120 := False;
  end;
  if v120 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-bench-engines-disagree'); Halt(1); end;
  end;
  v121 := 200;
  v122 := 32;
  v123 := 1;
  v124 := 0;
  v125 := method18(v122, v121, v123, v124);
  v126 := method20(v122, v121, v123, v124);
  v127 := 16;
  v128 := 0;
  v129 := 1;
  v130 := method22(v127, v129, v128);
  v131 := v40 = v125;
  if v131 then begin
      v132 := v41 = v126;
      v133 := v132;
  end else begin
      v133 := False;
  end;
  if v133 then begin
      v134 := v57 = v130;
      v135 := v134;
  end else begin
      v135 := False;
  end;
  if v135 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-bench-engines-disagree'); Halt(1); end;
  end;
  v136 := 200;
  v137 := 32;
  tmp139 := nil;
  SetLength(tmp139, 4096);
  v138 := tmp139;
  tmp141 := nil;
  SetLength(tmp141, 4096);
  v139 := tmp141;
  tmp143 := nil;
  SetLength(tmp143, 4096);
  v140 := tmp143;
  tmp145 := nil;
  SetLength(tmp145, 4096);
  v141 := tmp145;
  tmp147 := nil;
  SetLength(tmp147, 8192);
  v142 := tmp147;
  tmp149 := nil;
  SetLength(tmp149, 8192);
  v143 := tmp149;
  tmp151 := nil;
  SetLength(tmp151, 1);
  v144 := tmp151;
  v145 := 0;
  method24(v142, v145);
  v146 := 0;
  method24(v143, v146);
  v147 := 0;
  method25(v144, v147);
  v148 := 0;
  v149 := 0;
  v150 := 0;
  v151 := method26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150);
  v152 := 1;
  v153 := 0;
  v154 := 0;
  v155 := method26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154);
  v156 := v151 = 0;
  if v156 then begin
      v157 := v155 = 1;
      v158 := v157;
  end else begin
      v158 := False;
  end;
  if v158 then begin
      v166 := v138;
      v167 := v139;
      v168 := v140;
      v169 := v141;
      v170 := v142;
      v171 := v143;
      v172 := v144;
  end else begin
      begin WriteLn(StdErr, 'brzozowski-interned-store-init'); Halt(1); end;
  end;
  v173 := US0_0;
  v174 := UH0_2(v173);
  v175 := US0_1;
  v176 := UH0_2(v175);
  v177 := UH0_3(v174, v176);
  v178 := UH0_5(v177);
  v179 := US0_0;
  v180 := UH0_2(v179);
  v181 := UH0_4(v178, v180);
  v182 := method28(v166, v167, v168, v169, v170, v171, v172, v181);
  v183 := 1;
  v184 := 0;
  v185 := method32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184);
  v186 := US0_0;
  v187 := UH0_2(v186);
  v188 := US0_1;
  v189 := UH0_2(v188);
  v190 := UH0_3(v187, v189);
  v191 := UH0_5(v190);
  v192 := US0_1;
  v193 := UH0_2(v192);
  v194 := US0_0;
  v195 := UH0_2(v194);
  v196 := US0_1;
  v197 := UH0_2(v196);
  v198 := UH0_3(v195, v197);
  v199 := US0_0;
  v200 := UH0_2(v199);
  v201 := US0_1;
  v202 := UH0_2(v201);
  v203 := UH0_3(v200, v202);
  v204 := US0_0;
  v205 := UH0_2(v204);
  v206 := US0_1;
  v207 := UH0_2(v206);
  v208 := UH0_3(v205, v207);
  v209 := UH0_4(v203, v208);
  v210 := UH0_4(v198, v209);
  v211 := UH0_4(v193, v210);
  v212 := UH0_4(v191, v211);
  v213 := method28(v166, v167, v168, v169, v170, v171, v172, v212);
  v214 := 1;
  v215 := 0;
  v216 := method32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215);
  v217 := 16;
  tmp219 := nil;
  SetLength(tmp219, 4096);
  v218 := tmp219;
  tmp221 := nil;
  SetLength(tmp221, 4096);
  v219 := tmp221;
  tmp223 := nil;
  SetLength(tmp223, 4096);
  v220 := tmp223;
  tmp225 := nil;
  SetLength(tmp225, 4096);
  v221 := tmp225;
  tmp227 := nil;
  SetLength(tmp227, 8192);
  v222 := tmp227;
  tmp229 := nil;
  SetLength(tmp229, 8192);
  v223 := tmp229;
  tmp231 := nil;
  SetLength(tmp231, 1);
  v224 := tmp231;
  v225 := 0;
  method24(v222, v225);
  v226 := 0;
  method24(v223, v226);
  v227 := 0;
  method25(v224, v227);
  v228 := 0;
  v229 := 0;
  v230 := 0;
  v231 := method26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230);
  v232 := 1;
  v233 := 0;
  v234 := 0;
  v235 := method26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234);
  v236 := v231 = 0;
  if v236 then begin
      v237 := v235 = 1;
      v238 := v237;
  end else begin
      v238 := False;
  end;
  if v238 then begin
      v246 := v218;
      v247 := v219;
      v248 := v220;
      v249 := v221;
      v250 := v222;
      v251 := v223;
      v252 := v224;
  end else begin
      begin WriteLn(StdErr, 'brzozowski-interned-store-init'); Halt(1); end;
  end;
  v253 := US0_0;
  v254 := UH0_2(v253);
  v255 := US0_0;
  v256 := UH0_2(v255);
  v257 := US0_0;
  v258 := UH0_2(v257);
  v259 := UH0_4(v256, v258);
  v260 := UH0_3(v254, v259);
  v261 := UH0_5(v260);
  v262 := US0_1;
  v263 := UH0_2(v262);
  v264 := UH0_4(v261, v263);
  v265 := method28(v246, v247, v248, v249, v250, v251, v252, v264);
  v266 := 1;
  v267 := 0;
  v268 := method36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267);
  v269 := v40 = v185;
  if v269 then begin
      v270 := v41 = v216;
      v271 := v270;
  end else begin
      v271 := False;
  end;
  if v271 then begin
      v272 := v57 = v268;
      v273 := v272;
  end else begin
      v273 := False;
  end;
  if v273 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-bench-engines-disagree'); Halt(1); end;
  end;
  v274 := v57 = 16;
  if v274 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-bench-zero-runs-count'); Halt(1); end;
  end;
  v275 := v40 = 93;
  if v275 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-bench-ends-with-zero-count'); Halt(1); end;
  end;
  v276 := v41 = 97;
  if v276 then begin
  end else begin
      begin WriteLn(StdErr, 'brzozowski-bench-fourth-from-end-count'); Halt(1); end;
  end;
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
