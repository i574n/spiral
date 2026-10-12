program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  THeap0 = record l0: TFun0; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function HeapCreate0(a0: TFun0): THeap0;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: THeap0;
  v3: TFun0;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 3;
  v1 := ClosureCreate0(v0);
  v2 := HeapCreate0(v1);
  v3 := v2.l0;
  v4 := v3.Invoke(4);
  v5 := v4 = 7;
  if v5 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
