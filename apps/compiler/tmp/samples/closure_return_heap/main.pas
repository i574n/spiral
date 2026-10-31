program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun1 = class;
  THeap0 = record l0: LongInt; end;
  TFun1 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TFun0 = class
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap0; function Invoke(v1: LongInt): TFun1; override; end;
  Tg_c1 = class(TFun1) v0: THeap0; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
function ClosureCreate1(v0: THeap0; v1: LongInt): TFun1; forward;
function ClosureCreate0(v0: THeap0): TFun0; forward;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function Tg_c1.Invoke(v2: LongInt): LongInt;
var
  v3: LongInt;
  v4: Boolean;
begin
  v3 := v0.l0;
  v4 := v1 = 0;
  if v4 then begin
      Result := 0;
  end else begin
      Result := v3;
  end;
end;
function ClosureCreate1(v0: THeap0; v1: LongInt): TFun1;
var c: Tg_c1;
begin
  c := Tg_c1.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function Tf_c0.Invoke(v1: LongInt): TFun1;
begin
  Result := ClosureCreate1(v0, v1);
end;
function ClosureCreate0(v0: THeap0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: THeap0;
  v2: TFun0;
  v3: TFun1;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 7;
  v1 := HeapCreate0(v0);
  v2 := ClosureCreate0(v1);
  v3 := v2.Invoke(1);
  v4 := v3.Invoke(0);
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
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
