program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: AnsiString; end;
function MutCreate0(a0: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TMut0;
  v2: AnsiString;
  v3: AnsiString;
  v4: Boolean;
begin
  v0 := 'no';
  v1 := MutCreate0(v0);
  v2 := 'hi';
  v1.l0 := v2;
  v3 := v1.l0;
  v4 := v3 = 'hi';
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
