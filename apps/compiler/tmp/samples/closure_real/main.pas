program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): Double; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: Double; function Invoke(v1: LongInt): Double; override; end;
function ClosureCreate0(v0: Double): TFun0; forward;
function Tf_c0.Invoke(v1: LongInt): Double;
var
  v2: Boolean;
begin
  v2 := v1 = 0;
  if v2 then begin
      Result := 0.0;
  end else begin
      Result := v0;
  end;
end;
function ClosureCreate0(v0: Double): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: Double;
  v1: TFun0;
  v2: Double;
  v3: Boolean;
begin
  v0 := 1.5;
  v1 := ClosureCreate0(v0);
  v2 := v1.Invoke(1);
  v3 := v2 = 1.5;
  if v3 then begin
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
