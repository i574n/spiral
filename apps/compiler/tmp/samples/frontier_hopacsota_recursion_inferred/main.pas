program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function count_0(v0: LongInt): LongInt; forward;
function count_0(v0: LongInt): LongInt;
var
  v1: Boolean;
  v2: LongInt;
begin
  while True do begin
      v1 := v0 <= 0;
      if v1 then begin
          Result := 0;
          Exit;
      end else begin
          v2 := v0 - 1;
          v0 := v2;
          Continue;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 5;
  Result := count_0(v0);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
