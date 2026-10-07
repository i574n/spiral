program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH1 = class;
  TUH2 = class;
  TUH3 = class;
  TUH4 = class;
  TUH5 = class;
  TUH6 = class;
  TUH7 = class;
  TUH8 = class;
  TUS0 = record tag: LongInt;  end;
  TUH0 = class tag: LongInt; c1_0: TUS0; c1_1: TUH0; end;
  TUH2 = class tag: LongInt; c1_0: TUS0; c1_1: TUH2; end;
  TUH1 = class tag: LongInt; c1_0: TUH2; c1_1: TUH1; end;
  TUS1 = record tag: LongInt;  end;
  TUH3 = class tag: LongInt; c1_0: TUS1; c1_1: TUH3; end;
  TUH5 = class tag: LongInt; c1_0: TUS1; c1_1: TUH5; end;
  TUH4 = class tag: LongInt; c1_0: TUH5; c1_1: TUH4; end;
  TUS2 = record tag: LongInt;  end;
  TUH6 = class tag: LongInt; c1_0: TUS2; c1_1: TUH6; end;
  TUH7 = class tag: LongInt; c2_0: TUS0; c3_0: TUH7; c3_1: TUH7; c4_0: TUH7; c4_1: TUH7; c5_0: TUH7; end;
  TUS3 = record tag: LongInt;  end;
  TUS4 = record tag: LongInt;  end;
  TUS5 = record tag: LongInt;  end;
  TUH8 = class tag: LongInt; c2_0: TUS1; c3_0: TUH8; c3_1: TUH8; c4_0: TUH8; c4_1: TUH8; c5_0: TUH8; end;
function method0(v0: TUH0): TUH1; forward;
function method2(v0: TUH1; v1: TUH1): TUH1; forward;
function method3(v0: TUS0; v1: TUH1): TUH1; forward;
function method1(v0: TUH0; v1: TUH1): TUH1; forward;
function method4(v0: TUH3): TUH4; forward;
function method6(v0: TUH4; v1: TUH4): TUH4; forward;
function method7(v0: TUS1; v1: TUH4): TUH4; forward;
function method5(v0: TUH3; v1: TUH4): TUH4; forward;
function method9(v0: LongInt; v1: TUH2): TUS3; forward;
function method15(v0: TUH7; v1: TUH7): TUS4; forward;
function method14(v0: TUH7; v1: TUH7): TUH7; forward;
function method13(v0: TUH7; v1: TUH7): TUH7; forward;
function method17(v0: TUH7; v1: TUH7): Boolean; forward;
function method16(v0: TUH7; v1: TUH7): TUH7; forward;
function method18(v0: TUH7): TUH7; forward;
function method12(v0: TUH7): TUH7; forward;
function method20(v0: TUH7): TUS5; forward;
function method19(v0: TUH7; v1: TUS0): TUH7; forward;
function method11(v0: TUH7; v1: TUS0): TUH7; forward;
function method10(v0: TUH7; v1: TUH2): Boolean; forward;
function method8(v0: TUH7; v1: TUH1): Boolean; forward;
function method22(v0: LongInt; v1: TUH5): TUS3; forward;
function method28(v0: TUH8; v1: TUH8): TUS4; forward;
function method27(v0: TUH8; v1: TUH8): TUH8; forward;
function method26(v0: TUH8; v1: TUH8): TUH8; forward;
function method30(v0: TUH8; v1: TUH8): Boolean; forward;
function method29(v0: TUH8; v1: TUH8): TUH8; forward;
function method31(v0: TUH8): TUH8; forward;
function method25(v0: TUH8): TUH8; forward;
function method33(v0: TUH8): TUS5; forward;
function method32(v0: TUH8; v1: TUS1): TUH8; forward;
function method24(v0: TUH8; v1: TUS1): TUH8; forward;
function method23(v0: TUH8; v1: TUH5): Boolean; forward;
function method21(v0: TUH8; v1: TUH4): Boolean; forward;
function method34(v0: LongInt; v1: TUH6): TUS3; forward;
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
function UH2_0: TUH2;
begin
  Result := TUH2.Create; Result.tag := 0; 
end;
function UH2_1(a0: TUS0; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function UH1_0: TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; 
end;
function UH1_1(a0: TUH2; a1: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function method0(v0: TUH0): TUH1;
var
  v2: TUS0;
  v3: TUH0;
  v4: TUH1;
  v5: TUH2;
  v6: TUH2;
begin
  case v0.tag of
      1: begin // SymbolListCons
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := method0(v3);
          v5 := UH2_0;
          v6 := UH2_1(v2, v5);
          Result := UH1_1(v6, v4);
      end;
      0: begin // SymbolListNil
          Result := UH1_0;
      end;
  end;
end;
function method2(v0: TUH1; v1: TUH1): TUH1;
var
  v2: TUH2;
  v3: TUH1;
  v4: TUH1;
begin
  case v0.tag of
      1: begin // InputListCons
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := method2(v3, v1);
          Result := UH1_1(v2, v4);
      end;
      0: begin // InputListNil
          Result := v1;
      end;
  end;
end;
function method3(v0: TUS0; v1: TUH1): TUH1;
var
  v3: TUH2;
  v4: TUH1;
  v5: TUH1;
  v6: TUH2;
begin
  case v1.tag of
      1: begin // InputListCons
          v3 := v1.c1_0;
          v4 := v1.c1_1;
          v5 := method3(v0, v4);
          v6 := UH2_1(v0, v3);
          Result := UH1_1(v6, v5);
      end;
      0: begin // InputListNil
          Result := UH1_0;
      end;
  end;
end;
function method1(v0: TUH0; v1: TUH1): TUH1;
var
  v3: TUS0;
  v4: TUH0;
  v5: TUH1;
  v6: TUH1;
begin
  case v0.tag of
      1: begin // SymbolListCons
          v3 := v0.c1_0;
          v4 := v0.c1_1;
          v5 := method3(v3, v1);
          v6 := method1(v4, v1);
          Result := method2(v5, v6);
      end;
      0: begin // SymbolListNil
          Result := UH1_0;
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
function UH3_0: TUH3;
begin
  Result := TUH3.Create; Result.tag := 0; 
end;
function UH3_1(a0: TUS1; a1: TUH3): TUH3;
begin
  Result := TUH3.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function UH5_0: TUH5;
begin
  Result := TUH5.Create; Result.tag := 0; 
end;
function UH5_1(a0: TUS1; a1: TUH5): TUH5;
begin
  Result := TUH5.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function UH4_0: TUH4;
begin
  Result := TUH4.Create; Result.tag := 0; 
end;
function UH4_1(a0: TUH5; a1: TUH4): TUH4;
begin
  Result := TUH4.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function method4(v0: TUH3): TUH4;
var
  v2: TUS1;
  v3: TUH3;
  v4: TUH4;
  v5: TUH5;
  v6: TUH5;
begin
  case v0.tag of
      1: begin // SymbolListCons
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := method4(v3);
          v5 := UH5_0;
          v6 := UH5_1(v2, v5);
          Result := UH4_1(v6, v4);
      end;
      0: begin // SymbolListNil
          Result := UH4_0;
      end;
  end;
end;
function method6(v0: TUH4; v1: TUH4): TUH4;
var
  v2: TUH5;
  v3: TUH4;
  v4: TUH4;
begin
  case v0.tag of
      1: begin // InputListCons
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := method6(v3, v1);
          Result := UH4_1(v2, v4);
      end;
      0: begin // InputListNil
          Result := v1;
      end;
  end;
end;
function method7(v0: TUS1; v1: TUH4): TUH4;
var
  v3: TUH5;
  v4: TUH4;
  v5: TUH4;
  v6: TUH5;
begin
  case v1.tag of
      1: begin // InputListCons
          v3 := v1.c1_0;
          v4 := v1.c1_1;
          v5 := method7(v0, v4);
          v6 := UH5_1(v0, v3);
          Result := UH4_1(v6, v5);
      end;
      0: begin // InputListNil
          Result := UH4_0;
      end;
  end;
end;
function method5(v0: TUH3; v1: TUH4): TUH4;
var
  v3: TUS1;
  v4: TUH3;
  v5: TUH4;
  v6: TUH4;
begin
  case v0.tag of
      1: begin // SymbolListCons
          v3 := v0.c1_0;
          v4 := v0.c1_1;
          v5 := method7(v3, v1);
          v6 := method5(v4, v1);
          Result := method6(v5, v6);
      end;
      0: begin // SymbolListNil
          Result := UH4_0;
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
function US2_2: TUS2;
begin
  Result.tag := 2; 
end;
function UH6_0: TUH6;
begin
  Result := TUH6.Create; Result.tag := 0; 
end;
function UH6_1(a0: TUS2; a1: TUH6): TUH6;
begin
  Result := TUH6.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function UH7_0: TUH7;
begin
  Result := TUH7.Create; Result.tag := 0; 
end;
function UH7_1: TUH7;
begin
  Result := TUH7.Create; Result.tag := 1; 
end;
function UH7_2(a0: TUS0): TUH7;
begin
  Result := TUH7.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH7_3(a0: TUH7; a1: TUH7): TUH7;
begin
  Result := TUH7.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH7_4(a0: TUH7; a1: TUH7): TUH7;
begin
  Result := TUH7.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH7_5(a0: TUH7): TUH7;
begin
  Result := TUH7.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function US3_0: TUS3;
begin
  Result.tag := 0; 
end;
function US3_1: TUS3;
begin
  Result.tag := 1; 
end;
function US3_2: TUS3;
begin
  Result.tag := 2; 
end;
function US4_0: TUS4;
begin
  Result.tag := 0; 
end;
function US4_1: TUS4;
begin
  Result.tag := 1; 
end;
function US4_2: TUS4;
begin
  Result.tag := 2; 
end;
function method9(v0: LongInt; v1: TUH2): TUS3;
var
  v6: TUS0;
  v7: TUH2;
  v11: TUS4;
  v12: Boolean;
  v19: LongInt;
  v16: TUS4;
  v17: Boolean;
  v20: Boolean;
  v22: Boolean;
  v27: LongInt;
  v23: Boolean;
  v25: Boolean;
  tmp12: LongInt;
  tmp13: TUH2;
  v2: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin // InputCons
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              case v6.tag of
                  1: begin // BitOne
                      v11 := US4_2;
                  end;
                  0: begin // BitZero
                      v11 := US4_1;
                  end;
              end;
              case v11.tag of
                  1: begin // SymbolSame
                      v12 := True;
                  end;
                  else begin
                      v12 := False;
                  end;
              end;
              if v12 then begin
                  v19 := 0;
              end else begin
                  case v6.tag of
                      1: begin // BitOne
                          v16 := US4_1;
                      end;
                      0: begin // BitZero
                          v16 := US4_0;
                      end;
                  end;
                  case v16.tag of
                      1: begin // SymbolSame
                          v17 := True;
                      end;
                      else begin
                          v17 := False;
                      end;
                  end;
                  if v17 then begin
                      v19 := 1;
                  end else begin
                      v19 := (-1);
                  end;
              end;
              v20 := v19 < 0;
              if v20 then begin
                  Result := US3_2;
                  Exit;
              end else begin
                  v22 := v0 = 0;
                  if v22 then begin
                      v23 := v19 = 0;
                      if v23 then begin
                          v27 := 0;
                      end else begin
                          v27 := 1;
                      end;
                  end else begin
                      v25 := v19 = 0;
                      if v25 then begin
                          v27 := 0;
                      end else begin
                          v27 := 1;
                      end;
                  end;
                  tmp12 := v27;
                  tmp13 := v7;
                  v0 := tmp12;
                  v1 := tmp13;
                  Continue;
              end;
          end;
          0: begin // InputEmpty
              v2 := v0 = 0;
              if v2 then begin
                  Result := US3_0;
                  Exit;
              end else begin
                  Result := US3_1;
                  Exit;
              end;
          end;
      end;
  end;
end;
function method15(v0: TUH7; v1: TUH7): TUS4;
var
  v53: TUH7;
  v54: TUH7;
  v55: TUH7;
  v56: TUH7;
  v57: TUS4;
  tmp5: TUH7;
  tmp6: TUH7;
  v28: TUH7;
  v29: TUH7;
  v34: TUH7;
  v35: TUH7;
  v36: TUS4;
  tmp12: TUH7;
  tmp13: TUH7;
  v32: TUS0;
  v10: TUS0;
  v13: TUS0;
  v44: TUH7;
  v45: TUH7;
  v46: TUH7;
  v48: TUH7;
  tmp21: TUH7;
  tmp22: TUH7;
begin
  while True do begin
      case v0.tag of
          3: begin // RegexAlt
              v53 := v0.c3_0;
              v54 := v0.c3_1;
              case v1.tag of
                  3: begin // RegexAlt
                      v55 := v1.c3_0;
                      v56 := v1.c3_1;
                      v57 := method15(v53, v55);
                      case v57.tag of
                          1: begin // SymbolSame
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
                      Result := US4_2;
                      Exit;
                  end;
              end;
          end;
          4: begin // RegexCat
              v28 := v0.c4_0;
              v29 := v0.c4_1;
              case v1.tag of
                  4: begin // RegexCat
                      v34 := v1.c4_0;
                      v35 := v1.c4_1;
                      v36 := method15(v28, v34);
                      case v36.tag of
                          1: begin // SymbolSame
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
                  2: begin // RegexChar
                      v32 := v1.c2_0;
                      Result := US4_2;
                      Exit;
                  end;
                  0: begin // RegexEmpty
                      Result := US4_2;
                      Exit;
                  end;
                  1: begin // RegexEpsilon
                      Result := US4_2;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          2: begin // RegexChar
              v10 := v0.c2_0;
              case v1.tag of
                  2: begin // RegexChar
                      v13 := v1.c2_0;
                      case v10.tag of
                          1: begin // BitOne
                              case v13.tag of
                                  1: begin // BitOne
                                      Result := US4_1;
                                      Exit;
                                  end;
                                  0: begin // BitZero
                                      Result := US4_2;
                                      Exit;
                                  end;
                              end;
                          end;
                          0: begin // BitZero
                              case v13.tag of
                                  1: begin // BitOne
                                      Result := US4_0;
                                      Exit;
                                  end;
                                  0: begin // BitZero
                                      Result := US4_1;
                                      Exit;
                                  end;
                              end;
                          end;
                      end;
                  end;
                  0: begin // RegexEmpty
                      Result := US4_2;
                      Exit;
                  end;
                  1: begin // RegexEpsilon
                      Result := US4_2;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          0: begin // RegexEmpty
              case v1.tag of
                  0: begin // RegexEmpty
                      Result := US4_1;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          1: begin // RegexEpsilon
              case v1.tag of
                  0: begin // RegexEmpty
                      Result := US4_2;
                      Exit;
                  end;
                  1: begin // RegexEpsilon
                      Result := US4_1;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          5: begin // RegexStar
              v44 := v0.c5_0;
              case v1.tag of
                  3: begin // RegexAlt
                      v45 := v1.c3_0;
                      v46 := v1.c3_1;
                      Result := US4_0;
                      Exit;
                  end;
                  5: begin // RegexStar
                      v48 := v1.c5_0;
                      tmp21 := v44;
                      tmp22 := v48;
                      v0 := tmp21;
                      v1 := tmp22;
                      Continue;
                  end;
                  else begin
                      Result := US4_2;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function method14(v0: TUH7; v1: TUH7): TUH7;
var
  v2: TUH7;
  v3: TUH7;
  v4: TUS4;
  v6: TUH7;
  v11: TUS4;
begin
  case v1.tag of
      3: begin // RegexAlt
          v2 := v1.c3_0;
          v3 := v1.c3_1;
          v4 := method15(v0, v2);
          case v4.tag of
              2: begin // SymbolGreater
                  v6 := method14(v0, v3);
                  Result := UH7_3(v2, v6);
              end;
              0: begin // SymbolLess
                  Result := UH7_3(v0, v1);
              end;
              1: begin // SymbolSame
                  Result := v1;
              end;
          end;
      end;
      0: begin // RegexEmpty
          Result := v0;
      end;
      else begin
          v11 := method15(v0, v1);
          case v11.tag of
              2: begin // SymbolGreater
                  Result := UH7_3(v1, v0);
              end;
              0: begin // SymbolLess
                  Result := UH7_3(v0, v1);
              end;
              1: begin // SymbolSame
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function method13(v0: TUH7; v1: TUH7): TUH7;
var
  v2: TUH7;
  v3: TUH7;
  v4: TUH7;
  tmp3: TUH7;
  tmp4: TUH7;
begin
  while True do begin
      case v0.tag of
          3: begin // RegexAlt
              v2 := v0.c3_0;
              v3 := v0.c3_1;
              v4 := method14(v2, v1);
              tmp3 := v3;
              tmp4 := v4;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin // RegexEmpty
              Result := v1;
              Exit;
          end;
          else begin
              Result := method14(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function method17(v0: TUH7; v1: TUH7): Boolean;
var
  v18: TUH7;
  v19: TUH7;
  v20: TUH7;
  v21: TUH7;
  v22: Boolean;
  tmp5: TUH7;
  tmp6: TUH7;
  v26: TUH7;
  v27: TUH7;
  v28: TUH7;
  v29: TUH7;
  v30: Boolean;
  tmp12: TUH7;
  tmp13: TUH7;
  v4: TUS0;
  v5: TUS0;
  v15: TUS4;
  v34: TUH7;
  v35: TUH7;
  tmp19: TUH7;
  tmp20: TUH7;
begin
  while True do begin
      case v0.tag of
          3: begin // RegexAlt
              v18 := v0.c3_0;
              v19 := v0.c3_1;
              case v1.tag of
                  3: begin // RegexAlt
                      v20 := v1.c3_0;
                      v21 := v1.c3_1;
                      v22 := method17(v18, v20);
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
          4: begin // RegexCat
              v26 := v0.c4_0;
              v27 := v0.c4_1;
              case v1.tag of
                  4: begin // RegexCat
                      v28 := v1.c4_0;
                      v29 := v1.c4_1;
                      v30 := method17(v26, v28);
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
          2: begin // RegexChar
              v4 := v0.c2_0;
              case v1.tag of
                  2: begin // RegexChar
                      v5 := v1.c2_0;
                      case v4.tag of
                          1: begin // BitOne
                              case v5.tag of
                                  1: begin // BitOne
                                      v15 := US4_1;
                                  end;
                                  0: begin // BitZero
                                      v15 := US4_2;
                                  end;
                              end;
                          end;
                          0: begin // BitZero
                              case v5.tag of
                                  1: begin // BitOne
                                      v15 := US4_0;
                                  end;
                                  0: begin // BitZero
                                      v15 := US4_1;
                                  end;
                              end;
                          end;
                      end;
                      case v15.tag of
                          1: begin // SymbolSame
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
          0: begin // RegexEmpty
              case v1.tag of
                  0: begin // RegexEmpty
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          1: begin // RegexEpsilon
              case v1.tag of
                  1: begin // RegexEpsilon
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          5: begin // RegexStar
              v34 := v0.c5_0;
              case v1.tag of
                  5: begin // RegexStar
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
function method16(v0: TUH7; v1: TUH7): TUH7;
var
  v12: TUH7;
  v13: TUH7;
  v14: TUH7;
  v4: TUH7;
  v5: TUH7;
  v6: Boolean;
begin
  case v0.tag of
      0: begin // RegexEmpty
          Result := UH7_0;
      end;
      else begin
          case v1.tag of
              0: begin // RegexEmpty
                  Result := UH7_0;
              end;
              else begin
                  case v0.tag of
                      1: begin // RegexEpsilon
                          Result := v1;
                      end;
                      else begin
                          case v1.tag of
                              1: begin // RegexEpsilon
                                  Result := v0;
                              end;
                              else begin
                                  case v0.tag of
                                      4: begin // RegexCat
                                          v12 := v0.c4_0;
                                          v13 := v0.c4_1;
                                          v14 := method16(v13, v1);
                                          Result := UH7_4(v12, v14);
                                      end;
                                      5: begin // RegexStar
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin // RegexStar
                                                  v5 := v1.c5_0;
                                                  v6 := method17(v4, v5);
                                                  if v6 then begin
                                                      Result := UH7_5(v4);
                                                  end else begin
                                                      Result := UH7_4(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH7_4(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH7_4(v0, v1);
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
function method18(v0: TUH7): TUH7;
var
  v3: TUH7;
begin
  case v0.tag of
      0: begin // RegexEmpty
          Result := UH7_1;
      end;
      1: begin // RegexEpsilon
          Result := UH7_1;
      end;
      5: begin // RegexStar
          v3 := v0.c5_0;
          Result := UH7_5(v3);
      end;
      else begin
          Result := UH7_5(v0);
      end;
  end;
end;
function method12(v0: TUH7): TUH7;
var
  v5: TUH7;
  v6: TUH7;
  v7: TUH7;
  v8: TUH7;
  v10: TUH7;
  v11: TUH7;
  v12: TUH7;
  v13: TUH7;
  v3: TUS0;
  v15: TUH7;
  v16: TUH7;
begin
  case v0.tag of
      3: begin // RegexAlt
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := method12(v5);
          v8 := method12(v6);
          Result := method13(v7, v8);
      end;
      4: begin // RegexCat
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := method12(v10);
          v13 := method12(v11);
          Result := method16(v12, v13);
      end;
      2: begin // RegexChar
          v3 := v0.c2_0;
          Result := UH7_2(v3);
      end;
      0: begin // RegexEmpty
          Result := UH7_0;
      end;
      1: begin // RegexEpsilon
          Result := UH7_1;
      end;
      5: begin // RegexStar
          v15 := v0.c5_0;
          v16 := method12(v15);
          Result := method18(v16);
      end;
  end;
end;
function US5_0: TUS5;
begin
  Result.tag := 0; 
end;
function US5_1: TUS5;
begin
  Result.tag := 1; 
end;
function method20(v0: TUH7): TUS5;
var
  v5: TUH7;
  v6: TUH7;
  v7: TUS5;
  v8: TUS5;
  v16: TUH7;
  v17: TUH7;
  v18: TUS5;
  v19: TUS5;
  v3: TUS0;
  v25: TUH7;
begin
  case v0.tag of
      3: begin // RegexAlt
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := method20(v5);
          v8 := method20(v6);
          case v7.tag of
              0: begin // Nullable
                  Result := US5_0;
              end;
              else begin
                  case v8.tag of
                      0: begin // Nullable
                          Result := US5_0;
                      end;
                      else begin
                          case v7.tag of
                              1: begin // NonNullable
                                  case v8.tag of
                                      1: begin // NonNullable
                                          Result := US5_1;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
      4: begin // RegexCat
          v16 := v0.c4_0;
          v17 := v0.c4_1;
          v18 := method20(v16);
          v19 := method20(v17);
          case v18.tag of
              0: begin // Nullable
                  case v19.tag of
                      0: begin // Nullable
                          Result := US5_0;
                      end;
                      else begin
                          Result := US5_1;
                      end;
                  end;
              end;
              else begin
                  Result := US5_1;
              end;
          end;
      end;
      2: begin // RegexChar
          v3 := v0.c2_0;
          Result := US5_1;
      end;
      0: begin // RegexEmpty
          Result := US5_1;
      end;
      1: begin // RegexEpsilon
          Result := US5_0;
      end;
      5: begin // RegexStar
          v25 := v0.c5_0;
          Result := US5_0;
      end;
  end;
end;
function method19(v0: TUH7; v1: TUS0): TUH7;
var
  v19: TUH7;
  v20: TUH7;
  v21: TUH7;
  v22: TUH7;
  v24: TUH7;
  v25: TUH7;
  v26: TUS5;
  v31: TUH7;
  v27: TUH7;
  v28: TUH7;
  v29: TUH7;
  v4: TUS0;
  v14: TUS4;
  v15: Boolean;
  v35: TUH7;
  v36: TUH7;
  v37: TUH7;
begin
  case v0.tag of
      3: begin // RegexAlt
          v19 := v0.c3_0;
          v20 := v0.c3_1;
          v21 := method19(v19, v1);
          v22 := method19(v20, v1);
          Result := method13(v21, v22);
      end;
      4: begin // RegexCat
          v24 := v0.c4_0;
          v25 := v0.c4_1;
          v26 := method20(v24);
          case v26.tag of
              1: begin // NonNullable
                  v31 := method19(v24, v1);
                  Result := method16(v31, v25);
              end;
              0: begin // Nullable
                  v27 := method19(v24, v1);
                  v28 := method16(v27, v25);
                  v29 := method19(v25, v1);
                  Result := method13(v28, v29);
              end;
          end;
      end;
      2: begin // RegexChar
          v4 := v0.c2_0;
          case v4.tag of
              1: begin // BitOne
                  case v1.tag of
                      1: begin // BitOne
                          v14 := US4_1;
                      end;
                      0: begin // BitZero
                          v14 := US4_2;
                      end;
                  end;
              end;
              0: begin // BitZero
                  case v1.tag of
                      1: begin // BitOne
                          v14 := US4_0;
                      end;
                      0: begin // BitZero
                          v14 := US4_1;
                      end;
                  end;
              end;
          end;
          case v14.tag of
              1: begin // SymbolSame
                  v15 := True;
              end;
              else begin
                  v15 := False;
              end;
          end;
          if v15 then begin
              Result := UH7_1;
          end else begin
              Result := UH7_0;
          end;
      end;
      0: begin // RegexEmpty
          Result := UH7_0;
      end;
      1: begin // RegexEpsilon
          Result := UH7_0;
      end;
      5: begin // RegexStar
          v35 := v0.c5_0;
          v36 := method19(v35, v1);
          v37 := method18(v35);
          Result := method16(v36, v37);
      end;
  end;
end;
function method11(v0: TUH7; v1: TUS0): TUH7;
var
  v2: TUH7;
  v3: TUH7;
begin
  v2 := method12(v0);
  v3 := method19(v2, v1);
  Result := method12(v3);
end;
function method10(v0: TUH7; v1: TUH2): Boolean;
var
  v6: TUS0;
  v7: TUH2;
  v8: TUH7;
  tmp3: TUH7;
  tmp4: TUH2;
  v2: TUH7;
  v3: TUS5;
begin
  while True do begin
      case v1.tag of
          1: begin // InputCons
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              v8 := method11(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin // InputEmpty
              v2 := method12(v0);
              v3 := method20(v2);
              case v3.tag of
                  1: begin // NonNullable
                      Result := False;
                      Exit;
                  end;
                  0: begin // Nullable
                      Result := True;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function method8(v0: TUH7; v1: TUH1): Boolean;
var
  v2: TUH2;
  v3: TUH1;
  v4: LongInt;
  v5: TUS3;
  v11: Boolean;
  v7: Boolean;
  v8: Boolean;
  tmp7: TUH7;
  tmp8: TUH1;
begin
  while True do begin
      case v1.tag of
          1: begin // InputListCons
              v2 := v1.c1_0;
              v3 := v1.c1_1;
              v4 := 1;
              v5 := method9(v4, v2);
              case v5.tag of
                  0: begin // InventoryDfaAccepted
                      v11 := method10(v0, v2);
                  end;
                  2: begin // InventoryDfaInputOutsideInventory
                      v11 := False;
                  end;
                  1: begin // InventoryDfaRejected
                      v7 := method10(v0, v2);
                      v8 := v7 = False;
                      v11 := v8;
                  end;
              end;
              if v11 then begin
                  tmp7 := v0;
                  tmp8 := v3;
                  v0 := tmp7;
                  v1 := tmp8;
                  Continue;
              end else begin
                  Result := False;
                  Exit;
              end;
          end;
          0: begin // InputListNil
              Result := True;
              Exit;
          end;
      end;
  end;
end;
function UH8_0: TUH8;
begin
  Result := TUH8.Create; Result.tag := 0; 
end;
function UH8_1: TUH8;
begin
  Result := TUH8.Create; Result.tag := 1; 
end;
function UH8_2(a0: TUS1): TUH8;
begin
  Result := TUH8.Create; Result.tag := 2; Result.c2_0 := a0;
end;
function UH8_3(a0: TUH8; a1: TUH8): TUH8;
begin
  Result := TUH8.Create; Result.tag := 3; Result.c3_0 := a0; Result.c3_1 := a1;
end;
function UH8_4(a0: TUH8; a1: TUH8): TUH8;
begin
  Result := TUH8.Create; Result.tag := 4; Result.c4_0 := a0; Result.c4_1 := a1;
end;
function UH8_5(a0: TUH8): TUH8;
begin
  Result := TUH8.Create; Result.tag := 5; Result.c5_0 := a0;
end;
function method22(v0: LongInt; v1: TUH5): TUS3;
var
  v8: TUS1;
  v9: TUH5;
  v12: TUS4;
  v13: Boolean;
  v30: LongInt;
  v19: TUS4;
  v20: Boolean;
  v26: TUS4;
  v27: Boolean;
  v31: Boolean;
  v33: Boolean;
  v46: LongInt;
  v34: Boolean;
  v35: Boolean;
  v37: Boolean;
  v38: Boolean;
  v39: Boolean;
  v41: Boolean;
  v42: Boolean;
  tmp19: LongInt;
  tmp20: TUH5;
  v2: Boolean;
  v4: Boolean;
  v3: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin // InputCons
              v8 := v1.c1_0;
              v9 := v1.c1_1;
              case v8.tag of
                  0: begin // TriA
                      v12 := US4_1;
                  end;
                  else begin
                      v12 := US4_2;
                  end;
              end;
              case v12.tag of
                  1: begin // SymbolSame
                      v13 := True;
                  end;
                  else begin
                      v13 := False;
                  end;
              end;
              if v13 then begin
                  v30 := 0;
              end else begin
                  case v8.tag of
                      0: begin // TriA
                          v19 := US4_0;
                      end;
                      1: begin // TriB
                          v19 := US4_1;
                      end;
                      2: begin // TriC
                          v19 := US4_2;
                      end;
                  end;
                  case v19.tag of
                      1: begin // SymbolSame
                          v20 := True;
                      end;
                      else begin
                          v20 := False;
                      end;
                  end;
                  if v20 then begin
                      v30 := 1;
                  end else begin
                      case v8.tag of
                          0: begin // TriA
                              v26 := US4_0;
                          end;
                          1: begin // TriB
                              v26 := US4_0;
                          end;
                          2: begin // TriC
                              v26 := US4_1;
                          end;
                      end;
                      case v26.tag of
                          1: begin // SymbolSame
                              v27 := True;
                          end;
                          else begin
                              v27 := False;
                          end;
                      end;
                      if v27 then begin
                          v30 := 2;
                      end else begin
                          v30 := (-1);
                      end;
                  end;
              end;
              v31 := v30 < 0;
              if v31 then begin
                  Result := US3_2;
                  Exit;
              end else begin
                  v33 := v0 = 0;
                  if v33 then begin
                      v34 := v30 = 0;
                      if v34 then begin
                          v46 := 0;
                      end else begin
                          v35 := v30 = 1;
                          v46 := 0;
                      end;
                  end else begin
                      v37 := v0 = 1;
                      if v37 then begin
                          v38 := v30 = 0;
                          if v38 then begin
                              v46 := 0;
                          end else begin
                              v39 := v30 = 1;
                              v46 := 0;
                          end;
                      end else begin
                          v41 := v30 = 0;
                          if v41 then begin
                              v46 := 2;
                          end else begin
                              v42 := v30 = 1;
                              if v42 then begin
                                  v46 := 2;
                              end else begin
                                  v46 := 1;
                              end;
                          end;
                      end;
                  end;
                  tmp19 := v46;
                  tmp20 := v9;
                  v0 := tmp19;
                  v1 := tmp20;
                  Continue;
              end;
          end;
          0: begin // InputEmpty
              v2 := v0 = 0;
              if v2 then begin
                  v4 := False;
              end else begin
                  v3 := v0 = 1;
                  v4 := v3;
              end;
              if v4 then begin
                  Result := US3_0;
                  Exit;
              end else begin
                  Result := US3_1;
                  Exit;
              end;
          end;
      end;
  end;
end;
function method28(v0: TUH8; v1: TUH8): TUS4;
var
  v59: TUH8;
  v60: TUH8;
  v61: TUH8;
  v62: TUH8;
  v63: TUS4;
  tmp5: TUH8;
  tmp6: TUH8;
  v34: TUH8;
  v35: TUH8;
  v40: TUH8;
  v41: TUH8;
  v42: TUS4;
  tmp12: TUH8;
  tmp13: TUH8;
  v38: TUS1;
  v10: TUS1;
  v13: TUS1;
  v50: TUH8;
  v51: TUH8;
  v52: TUH8;
  v54: TUH8;
  tmp21: TUH8;
  tmp22: TUH8;
begin
  while True do begin
      case v0.tag of
          3: begin // RegexAlt
              v59 := v0.c3_0;
              v60 := v0.c3_1;
              case v1.tag of
                  3: begin // RegexAlt
                      v61 := v1.c3_0;
                      v62 := v1.c3_1;
                      v63 := method28(v59, v61);
                      case v63.tag of
                          1: begin // SymbolSame
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
                      Result := US4_2;
                      Exit;
                  end;
              end;
          end;
          4: begin // RegexCat
              v34 := v0.c4_0;
              v35 := v0.c4_1;
              case v1.tag of
                  4: begin // RegexCat
                      v40 := v1.c4_0;
                      v41 := v1.c4_1;
                      v42 := method28(v34, v40);
                      case v42.tag of
                          1: begin // SymbolSame
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
                  2: begin // RegexChar
                      v38 := v1.c2_0;
                      Result := US4_2;
                      Exit;
                  end;
                  0: begin // RegexEmpty
                      Result := US4_2;
                      Exit;
                  end;
                  1: begin // RegexEpsilon
                      Result := US4_2;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          2: begin // RegexChar
              v10 := v0.c2_0;
              case v1.tag of
                  2: begin // RegexChar
                      v13 := v1.c2_0;
                      case v10.tag of
                          0: begin // TriA
                              case v13.tag of
                                  0: begin // TriA
                                      Result := US4_1;
                                      Exit;
                                  end;
                                  else begin
                                      Result := US4_0;
                                      Exit;
                                  end;
                              end;
                          end;
                          else begin
                              case v13.tag of
                                  0: begin // TriA
                                      Result := US4_2;
                                      Exit;
                                  end;
                                  else begin
                                      case v10.tag of
                                          1: begin // TriB
                                              case v13.tag of
                                                  1: begin // TriB
                                                      Result := US4_1;
                                                      Exit;
                                                  end;
                                                  2: begin // TriC
                                                      Result := US4_0;
                                                      Exit;
                                                  end;
                                              end;
                                          end;
                                          2: begin // TriC
                                              case v13.tag of
                                                  1: begin // TriB
                                                      Result := US4_2;
                                                      Exit;
                                                  end;
                                                  2: begin // TriC
                                                      Result := US4_1;
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
                  0: begin // RegexEmpty
                      Result := US4_2;
                      Exit;
                  end;
                  1: begin // RegexEpsilon
                      Result := US4_2;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          0: begin // RegexEmpty
              case v1.tag of
                  0: begin // RegexEmpty
                      Result := US4_1;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          1: begin // RegexEpsilon
              case v1.tag of
                  0: begin // RegexEmpty
                      Result := US4_2;
                      Exit;
                  end;
                  1: begin // RegexEpsilon
                      Result := US4_1;
                      Exit;
                  end;
                  else begin
                      Result := US4_0;
                      Exit;
                  end;
              end;
          end;
          5: begin // RegexStar
              v50 := v0.c5_0;
              case v1.tag of
                  3: begin // RegexAlt
                      v51 := v1.c3_0;
                      v52 := v1.c3_1;
                      Result := US4_0;
                      Exit;
                  end;
                  5: begin // RegexStar
                      v54 := v1.c5_0;
                      tmp21 := v50;
                      tmp22 := v54;
                      v0 := tmp21;
                      v1 := tmp22;
                      Continue;
                  end;
                  else begin
                      Result := US4_2;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function method27(v0: TUH8; v1: TUH8): TUH8;
var
  v2: TUH8;
  v3: TUH8;
  v4: TUS4;
  v6: TUH8;
  v11: TUS4;
begin
  case v1.tag of
      3: begin // RegexAlt
          v2 := v1.c3_0;
          v3 := v1.c3_1;
          v4 := method28(v0, v2);
          case v4.tag of
              2: begin // SymbolGreater
                  v6 := method27(v0, v3);
                  Result := UH8_3(v2, v6);
              end;
              0: begin // SymbolLess
                  Result := UH8_3(v0, v1);
              end;
              1: begin // SymbolSame
                  Result := v1;
              end;
          end;
      end;
      0: begin // RegexEmpty
          Result := v0;
      end;
      else begin
          v11 := method28(v0, v1);
          case v11.tag of
              2: begin // SymbolGreater
                  Result := UH8_3(v1, v0);
              end;
              0: begin // SymbolLess
                  Result := UH8_3(v0, v1);
              end;
              1: begin // SymbolSame
                  Result := v1;
              end;
          end;
      end;
  end;
end;
function method26(v0: TUH8; v1: TUH8): TUH8;
var
  v2: TUH8;
  v3: TUH8;
  v4: TUH8;
  tmp3: TUH8;
  tmp4: TUH8;
begin
  while True do begin
      case v0.tag of
          3: begin // RegexAlt
              v2 := v0.c3_0;
              v3 := v0.c3_1;
              v4 := method27(v2, v1);
              tmp3 := v3;
              tmp4 := v4;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin // RegexEmpty
              Result := v1;
              Exit;
          end;
          else begin
              Result := method27(v0, v1);
              Exit;
          end;
      end;
  end;
end;
function method30(v0: TUH8; v1: TUH8): Boolean;
var
  v24: TUH8;
  v25: TUH8;
  v26: TUH8;
  v27: TUH8;
  v28: Boolean;
  tmp5: TUH8;
  tmp6: TUH8;
  v32: TUH8;
  v33: TUH8;
  v34: TUH8;
  v35: TUH8;
  v36: Boolean;
  tmp12: TUH8;
  tmp13: TUH8;
  v4: TUS1;
  v5: TUS1;
  v21: TUS4;
  v40: TUH8;
  v41: TUH8;
  tmp19: TUH8;
  tmp20: TUH8;
begin
  while True do begin
      case v0.tag of
          3: begin // RegexAlt
              v24 := v0.c3_0;
              v25 := v0.c3_1;
              case v1.tag of
                  3: begin // RegexAlt
                      v26 := v1.c3_0;
                      v27 := v1.c3_1;
                      v28 := method30(v24, v26);
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
          4: begin // RegexCat
              v32 := v0.c4_0;
              v33 := v0.c4_1;
              case v1.tag of
                  4: begin // RegexCat
                      v34 := v1.c4_0;
                      v35 := v1.c4_1;
                      v36 := method30(v32, v34);
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
          2: begin // RegexChar
              v4 := v0.c2_0;
              case v1.tag of
                  2: begin // RegexChar
                      v5 := v1.c2_0;
                      case v4.tag of
                          0: begin // TriA
                              case v5.tag of
                                  0: begin // TriA
                                      v21 := US4_1;
                                  end;
                                  else begin
                                      v21 := US4_0;
                                  end;
                              end;
                          end;
                          else begin
                              case v5.tag of
                                  0: begin // TriA
                                      v21 := US4_2;
                                  end;
                                  else begin
                                      case v4.tag of
                                          1: begin // TriB
                                              case v5.tag of
                                                  1: begin // TriB
                                                      v21 := US4_1;
                                                  end;
                                                  2: begin // TriC
                                                      v21 := US4_0;
                                                  end;
                                              end;
                                          end;
                                          2: begin // TriC
                                              case v5.tag of
                                                  1: begin // TriB
                                                      v21 := US4_2;
                                                  end;
                                                  2: begin // TriC
                                                      v21 := US4_1;
                                                  end;
                                              end;
                                          end;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                      case v21.tag of
                          1: begin // SymbolSame
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
          0: begin // RegexEmpty
              case v1.tag of
                  0: begin // RegexEmpty
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          1: begin // RegexEpsilon
              case v1.tag of
                  1: begin // RegexEpsilon
                      Result := True;
                      Exit;
                  end;
                  else begin
                      Result := False;
                      Exit;
                  end;
              end;
          end;
          5: begin // RegexStar
              v40 := v0.c5_0;
              case v1.tag of
                  5: begin // RegexStar
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
function method29(v0: TUH8; v1: TUH8): TUH8;
var
  v12: TUH8;
  v13: TUH8;
  v14: TUH8;
  v4: TUH8;
  v5: TUH8;
  v6: Boolean;
begin
  case v0.tag of
      0: begin // RegexEmpty
          Result := UH8_0;
      end;
      else begin
          case v1.tag of
              0: begin // RegexEmpty
                  Result := UH8_0;
              end;
              else begin
                  case v0.tag of
                      1: begin // RegexEpsilon
                          Result := v1;
                      end;
                      else begin
                          case v1.tag of
                              1: begin // RegexEpsilon
                                  Result := v0;
                              end;
                              else begin
                                  case v0.tag of
                                      4: begin // RegexCat
                                          v12 := v0.c4_0;
                                          v13 := v0.c4_1;
                                          v14 := method29(v13, v1);
                                          Result := UH8_4(v12, v14);
                                      end;
                                      5: begin // RegexStar
                                          v4 := v0.c5_0;
                                          case v1.tag of
                                              5: begin // RegexStar
                                                  v5 := v1.c5_0;
                                                  v6 := method30(v4, v5);
                                                  if v6 then begin
                                                      Result := UH8_5(v4);
                                                  end else begin
                                                      Result := UH8_4(v0, v1);
                                                  end;
                                              end;
                                              else begin
                                                  Result := UH8_4(v0, v1);
                                              end;
                                          end;
                                      end;
                                      else begin
                                          Result := UH8_4(v0, v1);
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
function method31(v0: TUH8): TUH8;
var
  v3: TUH8;
begin
  case v0.tag of
      0: begin // RegexEmpty
          Result := UH8_1;
      end;
      1: begin // RegexEpsilon
          Result := UH8_1;
      end;
      5: begin // RegexStar
          v3 := v0.c5_0;
          Result := UH8_5(v3);
      end;
      else begin
          Result := UH8_5(v0);
      end;
  end;
end;
function method25(v0: TUH8): TUH8;
var
  v5: TUH8;
  v6: TUH8;
  v7: TUH8;
  v8: TUH8;
  v10: TUH8;
  v11: TUH8;
  v12: TUH8;
  v13: TUH8;
  v3: TUS1;
  v15: TUH8;
  v16: TUH8;
begin
  case v0.tag of
      3: begin // RegexAlt
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := method25(v5);
          v8 := method25(v6);
          Result := method26(v7, v8);
      end;
      4: begin // RegexCat
          v10 := v0.c4_0;
          v11 := v0.c4_1;
          v12 := method25(v10);
          v13 := method25(v11);
          Result := method29(v12, v13);
      end;
      2: begin // RegexChar
          v3 := v0.c2_0;
          Result := UH8_2(v3);
      end;
      0: begin // RegexEmpty
          Result := UH8_0;
      end;
      1: begin // RegexEpsilon
          Result := UH8_1;
      end;
      5: begin // RegexStar
          v15 := v0.c5_0;
          v16 := method25(v15);
          Result := method31(v16);
      end;
  end;
end;
function method33(v0: TUH8): TUS5;
var
  v5: TUH8;
  v6: TUH8;
  v7: TUS5;
  v8: TUS5;
  v16: TUH8;
  v17: TUH8;
  v18: TUS5;
  v19: TUS5;
  v3: TUS1;
  v25: TUH8;
begin
  case v0.tag of
      3: begin // RegexAlt
          v5 := v0.c3_0;
          v6 := v0.c3_1;
          v7 := method33(v5);
          v8 := method33(v6);
          case v7.tag of
              0: begin // Nullable
                  Result := US5_0;
              end;
              else begin
                  case v8.tag of
                      0: begin // Nullable
                          Result := US5_0;
                      end;
                      else begin
                          case v7.tag of
                              1: begin // NonNullable
                                  case v8.tag of
                                      1: begin // NonNullable
                                          Result := US5_1;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
      4: begin // RegexCat
          v16 := v0.c4_0;
          v17 := v0.c4_1;
          v18 := method33(v16);
          v19 := method33(v17);
          case v18.tag of
              0: begin // Nullable
                  case v19.tag of
                      0: begin // Nullable
                          Result := US5_0;
                      end;
                      else begin
                          Result := US5_1;
                      end;
                  end;
              end;
              else begin
                  Result := US5_1;
              end;
          end;
      end;
      2: begin // RegexChar
          v3 := v0.c2_0;
          Result := US5_1;
      end;
      0: begin // RegexEmpty
          Result := US5_1;
      end;
      1: begin // RegexEpsilon
          Result := US5_0;
      end;
      5: begin // RegexStar
          v25 := v0.c5_0;
          Result := US5_0;
      end;
  end;
end;
function method32(v0: TUH8; v1: TUS1): TUH8;
var
  v25: TUH8;
  v26: TUH8;
  v27: TUH8;
  v28: TUH8;
  v30: TUH8;
  v31: TUH8;
  v32: TUS5;
  v37: TUH8;
  v33: TUH8;
  v34: TUH8;
  v35: TUH8;
  v4: TUS1;
  v20: TUS4;
  v21: Boolean;
  v41: TUH8;
  v42: TUH8;
  v43: TUH8;
begin
  case v0.tag of
      3: begin // RegexAlt
          v25 := v0.c3_0;
          v26 := v0.c3_1;
          v27 := method32(v25, v1);
          v28 := method32(v26, v1);
          Result := method26(v27, v28);
      end;
      4: begin // RegexCat
          v30 := v0.c4_0;
          v31 := v0.c4_1;
          v32 := method33(v30);
          case v32.tag of
              1: begin // NonNullable
                  v37 := method32(v30, v1);
                  Result := method29(v37, v31);
              end;
              0: begin // Nullable
                  v33 := method32(v30, v1);
                  v34 := method29(v33, v31);
                  v35 := method32(v31, v1);
                  Result := method26(v34, v35);
              end;
          end;
      end;
      2: begin // RegexChar
          v4 := v0.c2_0;
          case v4.tag of
              0: begin // TriA
                  case v1.tag of
                      0: begin // TriA
                          v20 := US4_1;
                      end;
                      else begin
                          v20 := US4_0;
                      end;
                  end;
              end;
              else begin
                  case v1.tag of
                      0: begin // TriA
                          v20 := US4_2;
                      end;
                      else begin
                          case v4.tag of
                              1: begin // TriB
                                  case v1.tag of
                                      1: begin // TriB
                                          v20 := US4_1;
                                      end;
                                      2: begin // TriC
                                          v20 := US4_0;
                                      end;
                                  end;
                              end;
                              2: begin // TriC
                                  case v1.tag of
                                      1: begin // TriB
                                          v20 := US4_2;
                                      end;
                                      2: begin // TriC
                                          v20 := US4_1;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
          case v20.tag of
              1: begin // SymbolSame
                  v21 := True;
              end;
              else begin
                  v21 := False;
              end;
          end;
          if v21 then begin
              Result := UH8_1;
          end else begin
              Result := UH8_0;
          end;
      end;
      0: begin // RegexEmpty
          Result := UH8_0;
      end;
      1: begin // RegexEpsilon
          Result := UH8_0;
      end;
      5: begin // RegexStar
          v41 := v0.c5_0;
          v42 := method32(v41, v1);
          v43 := method31(v41);
          Result := method29(v42, v43);
      end;
  end;
end;
function method24(v0: TUH8; v1: TUS1): TUH8;
var
  v2: TUH8;
  v3: TUH8;
begin
  v2 := method25(v0);
  v3 := method32(v2, v1);
  Result := method25(v3);
end;
function method23(v0: TUH8; v1: TUH5): Boolean;
var
  v6: TUS1;
  v7: TUH5;
  v8: TUH8;
  tmp3: TUH8;
  tmp4: TUH5;
  v2: TUH8;
  v3: TUS5;
begin
  while True do begin
      case v1.tag of
          1: begin // InputCons
              v6 := v1.c1_0;
              v7 := v1.c1_1;
              v8 := method24(v0, v6);
              tmp3 := v8;
              tmp4 := v7;
              v0 := tmp3;
              v1 := tmp4;
              Continue;
          end;
          0: begin // InputEmpty
              v2 := method25(v0);
              v3 := method33(v2);
              case v3.tag of
                  1: begin // NonNullable
                      Result := False;
                      Exit;
                  end;
                  0: begin // Nullable
                      Result := True;
                      Exit;
                  end;
              end;
          end;
      end;
  end;
end;
function method21(v0: TUH8; v1: TUH4): Boolean;
var
  v2: TUH5;
  v3: TUH4;
  v4: LongInt;
  v5: TUS3;
  v11: Boolean;
  v7: Boolean;
  v8: Boolean;
  tmp7: TUH8;
  tmp8: TUH4;
begin
  while True do begin
      case v1.tag of
          1: begin // InputListCons
              v2 := v1.c1_0;
              v3 := v1.c1_1;
              v4 := 2;
              v5 := method22(v4, v2);
              case v5.tag of
                  0: begin // InventoryDfaAccepted
                      v11 := method23(v0, v2);
                  end;
                  2: begin // InventoryDfaInputOutsideInventory
                      v11 := False;
                  end;
                  1: begin // InventoryDfaRejected
                      v7 := method23(v0, v2);
                      v8 := v7 = False;
                      v11 := v8;
                  end;
              end;
              if v11 then begin
                  tmp7 := v0;
                  tmp8 := v3;
                  v0 := tmp7;
                  v1 := tmp8;
                  Continue;
              end else begin
                  Result := False;
                  Exit;
              end;
          end;
          0: begin // InputListNil
              Result := True;
              Exit;
          end;
      end;
  end;
end;
function method34(v0: LongInt; v1: TUH6): TUS3;
var
  v7: TUS2;
  v8: TUH6;
  v11: TUS4;
  v12: Boolean;
  v21: LongInt;
  v18: TUS4;
  v19: Boolean;
  v22: Boolean;
  v24: Boolean;
  v28: LongInt;
  v25: Boolean;
  v26: Boolean;
  tmp12: LongInt;
  tmp13: TUH6;
  v2: Boolean;
  v3: Boolean;
begin
  while True do begin
      case v1.tag of
          1: begin // InputCons
              v7 := v1.c1_0;
              v8 := v1.c1_1;
              case v7.tag of
                  0: begin // ModelA
                      v11 := US4_1;
                  end;
                  else begin
                      v11 := US4_2;
                  end;
              end;
              case v11.tag of
                  1: begin // SymbolSame
                      v12 := True;
                  end;
                  else begin
                      v12 := False;
                  end;
              end;
              if v12 then begin
                  v21 := 0;
              end else begin
                  case v7.tag of
                      0: begin // ModelA
                          v18 := US4_0;
                      end;
                      1: begin // ModelB
                          v18 := US4_1;
                      end;
                      2: begin // ModelC
                          v18 := US4_2;
                      end;
                  end;
                  case v18.tag of
                      1: begin // SymbolSame
                          v19 := True;
                      end;
                      else begin
                          v19 := False;
                      end;
                  end;
                  if v19 then begin
                      v21 := 1;
                  end else begin
                      v21 := (-1);
                  end;
              end;
              v22 := v21 < 0;
              if v22 then begin
                  Result := US3_2;
                  Exit;
              end else begin
                  v24 := v0 = 0;
                  if v24 then begin
                      v25 := v21 = 0;
                      v28 := 0;
                  end else begin
                      v26 := v21 = 0;
                      if v26 then begin
                          v28 := 1;
                      end else begin
                          v28 := 0;
                      end;
                  end;
                  tmp12 := v28;
                  tmp13 := v8;
                  v0 := tmp12;
                  v1 := tmp13;
                  Continue;
              end;
          end;
          0: begin // InputEmpty
              v2 := v0 = 0;
              v3 := v2 = False;
              if v3 then begin
                  Result := US3_0;
                  Exit;
              end else begin
                  Result := US3_1;
                  Exit;
              end;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v1: TUS0;
  v2: TUH0;
  v3: TUH0;
  v4: TUH0;
  v5: TUH1;
  v6: TUH2;
  v7: TUH1;
  v8: TUS0;
  v9: TUS0;
  v10: TUH0;
  v11: TUH0;
  v12: TUH0;
  v13: TUS0;
  v14: TUS0;
  v15: TUH0;
  v16: TUH0;
  v17: TUH0;
  v18: TUH1;
  v19: TUH1;
  v20: TUH1;
  v21: TUS1;
  v22: TUS1;
  v23: TUS1;
  v24: TUH3;
  v25: TUH3;
  v26: TUH3;
  v27: TUH3;
  v28: TUH4;
  v29: TUH5;
  v30: TUH4;
  v31: TUS1;
  v32: TUS1;
  v33: TUS1;
  v34: TUH3;
  v35: TUH3;
  v36: TUH3;
  v37: TUH3;
  v38: TUS1;
  v39: TUS1;
  v40: TUS1;
  v41: TUH3;
  v42: TUH3;
  v43: TUH3;
  v44: TUH3;
  v45: TUH4;
  v46: TUH4;
  v47: TUH4;
  v48: TUS2;
  v49: TUH6;
  v50: TUH6;
  v51: TUS0;
  v52: TUH7;
  v53: TUS0;
  v54: TUH7;
  v55: TUH7;
  v56: TUH7;
  v57: TUS0;
  v58: TUH7;
  v59: TUH7;
  v60: Boolean;
  v75: Boolean;
  v61: TUS1;
  v62: TUH8;
  v63: TUS1;
  v64: TUH8;
  v65: TUH8;
  v66: TUH8;
  v67: TUS1;
  v68: TUH8;
  v69: TUH8;
  v70: Boolean;
  v71: LongInt;
  v72: TUS3;
begin
  v0 := US0_0;
  v1 := US0_1;
  v2 := UH0_0;
  v3 := UH0_1(v1, v2);
  v4 := UH0_1(v0, v3);
  v5 := method0(v4);
  v6 := UH2_0;
  v7 := UH1_1(v6, v5);
  v8 := US0_0;
  v9 := US0_1;
  v10 := UH0_0;
  v11 := UH0_1(v9, v10);
  v12 := UH0_1(v8, v11);
  v13 := US0_0;
  v14 := US0_1;
  v15 := UH0_0;
  v16 := UH0_1(v14, v15);
  v17 := UH0_1(v13, v16);
  v18 := method0(v17);
  v19 := method1(v12, v18);
  v20 := method2(v7, v19);
  v21 := US1_0;
  v22 := US1_1;
  v23 := US1_2;
  v24 := UH3_0;
  v25 := UH3_1(v23, v24);
  v26 := UH3_1(v22, v25);
  v27 := UH3_1(v21, v26);
  v28 := method4(v27);
  v29 := UH5_0;
  v30 := UH4_1(v29, v28);
  v31 := US1_0;
  v32 := US1_1;
  v33 := US1_2;
  v34 := UH3_0;
  v35 := UH3_1(v33, v34);
  v36 := UH3_1(v32, v35);
  v37 := UH3_1(v31, v36);
  v38 := US1_0;
  v39 := US1_1;
  v40 := US1_2;
  v41 := UH3_0;
  v42 := UH3_1(v40, v41);
  v43 := UH3_1(v39, v42);
  v44 := UH3_1(v38, v43);
  v45 := method4(v44);
  v46 := method5(v37, v45);
  v47 := method6(v30, v46);
  v48 := US2_2;
  v49 := UH6_0;
  v50 := UH6_1(v48, v49);
  v51 := US0_0;
  v52 := UH7_2(v51);
  v53 := US0_1;
  v54 := UH7_2(v53);
  v55 := UH7_3(v52, v54);
  v56 := UH7_5(v55);
  v57 := US0_0;
  v58 := UH7_2(v57);
  v59 := UH7_4(v56, v58);
  v60 := method8(v59, v20);
  if v60 then begin
      v61 := US1_0;
      v62 := UH8_2(v61);
      v63 := US1_1;
      v64 := UH8_2(v63);
      v65 := UH8_3(v62, v64);
      v66 := UH8_5(v65);
      v67 := US1_2;
      v68 := UH8_2(v67);
      v69 := UH8_4(v66, v68);
      v70 := method21(v69, v47);
      if v70 then begin
          v71 := 1;
          v72 := method34(v71, v50);
          case v72.tag of
              2: begin // InventoryDfaInputOutsideInventory
                  v75 := True;
              end;
              else begin
                  v75 := False;
              end;
          end;
      end else begin
          v75 := False;
      end;
  end else begin
      v75 := False;
  end;
  if v75 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
