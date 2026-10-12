program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
procedure method0(v0: TArray0); forward;
procedure method1(v0: TArray0); forward;
function method2(v0: TArray0): LongInt; forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize0(v0,v1);
end;
procedure method1(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 4;
  DynamicArrayResize0(v0,v1);
end;
function method2(v0: TArray0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  v2 := v1 - 15;
  Result := v2;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 4;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 1;
  v1[1] := 2;
  v1[2] := 3;
  v1[3] := 4;
  method0(v1);
  method1(v1);
  v1[3] := 7;
  v2 := LongInt(Length(v1));
  v3 := v1[3];
  v4 := v2 + v3;
  v5 := method2(v1);
  v6 := v4 + v5;
  Result := v6;
end;
begin
  Halt(SpiralMain);
end.
