program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TFun0 = class;
  TUH0 = class tag: LongInt; c1_0: LongInt; c1_1: TUH0; c1_2: TUH0; end;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: TUH0; function Invoke(v1: LongInt): LongInt; override; end;
function sum_0(v0: TUH0): LongInt; forward;
function ClosureCreate0(v0: TUH0): TFun0; forward;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: LongInt; a1: TUH0; a2: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function sum_0(v0: TUH0): LongInt;
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
          v4 := sum_0(v2);
          v5 := sum_0(v3);
          v6 := v4 + v5;
          v7 := v1 + v6;
          Result := v7;
      end;
  end;
end;
function TClosure0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := sum_0(v0);
  v3 := v2 + v1;
  Result := v3;
end;
function ClosureCreate0(v0: TUH0): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: LongInt;
  v2: TUH0;
  v3: TFun0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := UH0_0;
  v1 := 2;
  v2 := UH0_1(v1, v0, v0);
  v3 := ClosureCreate0(v2);
  v4 := v3.Invoke(19);
  v5 := v3.Invoke(19);
  v6 := v4 + v5;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
