program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function method0(v0: LongInt): TArray0; forward;
function method1(v0: TArray0; v1: LongInt): LongInt; forward;
function method0(v0: LongInt): TArray0;
var
  v1: TArray0;
  tmp1: TArray0;
begin
  tmp1 := nil;
  SetLength(tmp1, v0);
  v1 := tmp1;
  v1[0] := 3;
  v1[1] := 4;
  v1[2] := 8;
  Result := v1;
end;
function method1(v0: TArray0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v2 := v0[v1];
  v3 := LongInt(Length(v0));
  v4 := v2 + v3;
  v5 := v4 - 11;
  Result := v5;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  v2: LongInt;
begin
  v0 := 3;
  v1 := method0(v0);
  v2 := 2;
  Result := method1(v1, v2);
end;
begin
  Halt(SpiralMain);
end.
