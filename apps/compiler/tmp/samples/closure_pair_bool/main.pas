program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TTuple0 = record f0: Boolean; f1: Boolean; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: Boolean; function Invoke(v1: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: Boolean): TFun0; forward;
function TupleCreate0(f0: Boolean; f1: Boolean): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v1: LongInt): TTuple0;
var
  v2: Boolean;
begin
  v2 := v1 = 0;
  if v2 then begin
      Result := TupleCreate0(False, False);
  end else begin
      Result := TupleCreate0(v0, True);
  end;
end;
function ClosureCreate0(v0: Boolean): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: TFun0;
  v2: Boolean;
  v3: Boolean;
  tmp4: TTuple0;
  v4: Boolean;
begin
  v0 := True;
  v1 := ClosureCreate0(v0);
  tmp4 := v1.Invoke(1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := v2 and v3;
  if v4 then begin
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
