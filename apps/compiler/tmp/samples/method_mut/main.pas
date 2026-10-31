program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: LongInt; end;
function method0(v0: TMut0): TMut0; forward;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function method0(v0: TMut0): TMut0;
begin
  Result := v0;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: TMut0;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := MutCreate0(1);
  v1 := method0(v0);
  v1.l0 := 7;
  v2 := v1.l0;
  v3 := v2 = 7;
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
