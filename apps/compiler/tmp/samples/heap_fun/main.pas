program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tadd_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  THeap0 = record l0: TFun0; l1: LongInt; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function Tadd_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tadd_c0;
begin
  c := Tadd_c0.Create; c.v0 := v0;
  Result := c;
end;
function HeapCreate0(a0: TFun0; a1: LongInt): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: THeap0;
  v4: TFun0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := ClosureCreate0(v0);
  v3 := HeapCreate0(v2, v1);
  v4 := v3.l0;
  v5 := v3.l1;
  v6 := v4.Invoke(0);
  v7 := v6 + v5;
  v8 := v7 = 7;
  if v8 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
