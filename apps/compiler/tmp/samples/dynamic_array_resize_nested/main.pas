program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TArray1 = array of TArray0;
procedure method0(v0: TArray1); forward;
procedure method1(v0: TArray1); forward;
procedure method2(v0: TArray0); forward;
procedure method3(v0: TArray0); forward;
function method5(v0: TArray0): LongInt; forward;
function method4(v0: TArray0; v1: TArray1): LongInt; forward;
procedure method0(v0: TArray1);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0,v1);
end;
procedure method1(v0: TArray1);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0,v1);
end;
procedure method2(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize1(v0,v1);
end;
procedure method3(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize1(v0,v1);
end;
function method5(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity1(v0);
  Result := v1;
end;
function method4(v0: TArray0; v1: TArray1): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := DynamicArrayCapacity0(v1);
  v3 := method5(v0);
  v4 := v2 + v3;
  Result := v4;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: TArray1;
  tmp4: TArray1;
  v3: TArray0;
  v4: TArray0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
begin
  v0 := 1;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 7;
  tmp4 := nil;
  SetLength(tmp4, v0);
  v2 := tmp4;
  v2[0] := v1;
  v3 := v2[0];
  method0(v2);
  method1(v2);
  v2[0] := v3;
  method2(v1);
  method3(v3);
  v1[0] := 9;
  v4 := v2[0];
  v5 := v4[0];
  v6 := LongInt(Length(v4));
  v7 := v5 + v6;
  v8 := LongInt(Length(v2));
  v9 := v7 + v8;
  v10 := method4(v1, v2);
  v11 := v9 + v10;
  v12 := v11 - 13;
  Result := v12;
end;
begin
  Halt(SpiralMain);
end.
