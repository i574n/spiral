program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TArray1 = array of TArray0;
  TUS0 = record tag: LongInt; c1_0: TArray1; end;
procedure method1(v0: TArray0); forward;
procedure method2(v0: TArray0); forward;
procedure method3(v0: TArray0); forward;
function method4(v0: TArray0): LongInt; forward;
function method0(v0: TUS0): LongInt; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: TArray1): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
procedure method1(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayReserve1(v0,v1);
end;
procedure method2(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize1(v0,v1);
end;
procedure method3(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize1(v0,v1);
end;
function method4(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity1(v0);
  Result := v1;
end;
function method0(v0: TUS0): LongInt;
var
  v1: TArray1;
  v2: TArray0;
  v3: TArray0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
begin
  case v0.tag of
      0: begin // Empty
          Result := 0;
      end;
      1: begin // Nested
          v1 := v0.c1_0;
          v2 := v1[0];
          v3 := v1[1];
          method1(v2);
          method2(v3);
          method3(v3);
          v3[1] := 8;
          v4 := method4(v2);
          v5 := LongInt(Length(v1));
          v6 := v5 + v4;
          v7 := v2[0];
          v8 := v6 + v7;
          v9 := v2[1];
          v10 := v8 + v9;
          v11 := v3[0];
          v12 := v10 + v11;
          v13 := v3[1];
          v14 := v12 + v13;
          Result := v14;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray1;
  tmp2: TArray1;
  v2: TArray0;
  tmp4: TArray0;
  v3: TArray0;
  tmp6: TArray0;
  v4: TUS0;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  tmp4 := nil;
  SetLength(tmp4, v0);
  v2 := tmp4;
  tmp6 := nil;
  SetLength(tmp6, v0);
  v3 := tmp6;
  v2[0] := 3;
  v2[1] := 4;
  v3[0] := 5;
  v3[1] := 6;
  v1[0] := v2;
  v1[1] := v3;
  v4 := US0_1(v1);
  v5 := method0(v4);
  v6 := v5 - 26;
  Result := v6;
end;
begin
  Halt(SpiralMain);
end.
