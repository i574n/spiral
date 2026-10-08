program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH0 = class tag: LongInt; c1_0: LongInt; c1_1: TUH0; c1_2: TUH0; end;
function sum_1(v0: TUH0): LongInt; forward;
function consume_pair_0(v0: TUH0; v1: TUH0): LongInt; forward;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: LongInt; a1: TUH0; a2: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function sum_1(v0: TUH0): LongInt;
var
  v1: LongInt;
  v2: TUH0;
  v3: TUH0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  case v0.tag of
      0: begin
          Result := 0;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v0.c1_2;
          v4 := sum_1(v2);
          v5 := sum_1(v3);
          v6 := v4 + v5;
          v7 := v1 + v6;
          Result := v7;
      end;
  end;
end;
function consume_pair_0(v0: TUH0; v1: TUH0): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := sum_1(v0);
  v3 := sum_1(v1);
  v4 := v2 + v3;
  Result := v4;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TUH0;
  v3: TUH0;
  v4: TUH0;
  v5: LongInt;
  v6: LongInt;
  v7: TUH0;
  v8: TUH0;
  v9: TUH0;
  v10: LongInt;
  v11: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := UH0_0;
  v3 := UH0_1(v1, v2, v2);
  v4 := UH0_1(v0, v3, v3);
  v5 := 1;
  v6 := 2;
  v7 := UH0_0;
  v8 := UH0_1(v6, v7, v7);
  v9 := UH0_1(v5, v8, v8);
  v10 := consume_pair_0(v4, v9);
  v11 := v10 - 10;
  Result := v11;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
