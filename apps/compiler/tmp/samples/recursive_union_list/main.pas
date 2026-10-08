program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH0 = class tag: LongInt; c1_0: LongInt; c1_1: TUH0; end;
function sum_0(v0: TUH0): LongInt; forward;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: LongInt; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function sum_0(v0: TUH0): LongInt;
var
  v1: LongInt;
  v2: TUH0;
  v3: LongInt;
  v4: LongInt;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := sum_0(v2);
          v4 := v1 + v3;
          Result := v4;
      end;
      0: begin
          Result := 0;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: TUH0;
  v4: TUH0;
  v5: TUH0;
  v6: TUH0;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := 3;
  v3 := UH0_0;
  v4 := UH0_1(v2, v3);
  v5 := UH0_1(v1, v4);
  v6 := UH0_1(v0, v5);
  v7 := sum_0(v6);
  v8 := v7 - 6;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
