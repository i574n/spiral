program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut1 = class;
  TUH0 = class;
  TMut2 = class;
  TArray0 = array of LongInt;
  TMut0 = class l0: LongInt; end;
  TMut1 = class l0: LongInt; end;
  TUH0 = class tag: LongInt; c1_0: LongInt; c1_1: TUH0; end;
  TMut2 = class l0: TUH0; end;
function method0(v0: TMut0): Boolean; forward;
function method1(v0: TMut1): Boolean; forward;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function method0(v0: TMut0): Boolean;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := v0.l0;
  v2 := v1 < 3;
  Result := v2;
end;
function MutCreate1(a0: LongInt): TMut1;
begin
  Result := TMut1.Create; Result.l0 := a0;
end;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: LongInt; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function MutCreate2(a0: TUH0): TMut2;
begin
  Result := TMut2.Create; Result.l0 := a0;
end;
function method1(v0: TMut1): Boolean;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := v0.l0;
  v2 := v1 < 4;
  Result := v2;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: TMut0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: TMut1;
  v7: TMut1;
  v8: TUH0;
  v9: TMut2;
  v11: LongInt;
  v12: LongInt;
  v13: Boolean;
  v14: LongInt;
  v15: LongInt;
  v16: TUH0;
  v17: TUH0;
  v18: LongInt;
  v19: TUH0;
  v38: LongInt;
  v20: LongInt;
  v21: TUH0;
  v22: LongInt;
  v23: TUH0;
  v24: LongInt;
  v25: TUH0;
  v26: LongInt;
  v27: TUH0;
  v28: LongInt;
  v29: LongInt;
  v30: LongInt;
  v31: LongInt;
  v32: LongInt;
  v33: LongInt;
  v39: LongInt;
  v40: LongInt;
  v41: LongInt;
  v42: LongInt;
  v43: LongInt;
  v44: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 3);
  v0 := tmp1;
  v1 := MutCreate0(0);
  while method0(v1) do begin
      v3 := v1.l0;
      v4 := v3 * 5;
      v0[v3] := v4;
      v5 := v3 + 1;
      v1.l0 := v5;
  end;
  v6 := MutCreate1(0);
  v7 := MutCreate1(0);
  v8 := UH0_0;
  v9 := MutCreate2(v8);
  while method1(v6) do begin
      v11 := v6.l0;
      v12 := v11 mod 2;
      v13 := v12 = 1;
      if v13 then begin
          v14 := v7.l0;
          v15 := v14 + 1;
          v7.l0 := v15;
      end else begin
      end;
      v16 := v9.l0;
      v17 := UH0_1(v11, v16);
      v9.l0 := v17;
      v18 := v11 + 1;
      v6.l0 := v18;
  end;
  v19 := v9.l0;
  case v19.tag of
      1: begin // Cons
          v20 := v19.c1_0;
          v21 := v19.c1_1;
          case v21.tag of
              1: begin // Cons
                  v22 := v21.c1_0;
                  v23 := v21.c1_1;
                  case v23.tag of
                      1: begin // Cons
                          v24 := v23.c1_0;
                          v25 := v23.c1_1;
                          case v25.tag of
                              1: begin // Cons
                                  v26 := v25.c1_0;
                                  v27 := v25.c1_1;
                                  case v27.tag of
                                      0: begin // Nil
                                          v28 := v20 * 64;
                                          v29 := v22 * 16;
                                          v30 := v28 + v29;
                                          v31 := v24 * 4;
                                          v32 := v30 + v31;
                                          v33 := v32 + v26;
                                          v38 := v33;
                                      end;
                                      else begin
                                          v38 := (-1);
                                      end;
                                  end;
                              end;
                              else begin
                                  v38 := (-1);
                              end;
                          end;
                      end;
                      else begin
                          v38 := (-1);
                      end;
                  end;
              end;
              else begin
                  v38 := (-1);
              end;
          end;
      end;
      else begin
          v38 := (-1);
      end;
  end;
  v39 := v7.l0;
  v40 := v38 + v39;
  v41 := v0[2];
  v42 := v40 + v41;
  v43 := v0[1];
  v44 := v42 - v43;
  Result := v44;
end;
begin
  Halt(SpiralMain);
end.
