program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiChar;
  v1: AnsiChar;
  v2: Boolean;
  v3: Boolean;
  v4: Boolean;
begin
  v0 := 'a';
  v1 := 'b';
  v2 := v0 < v1;
  if v2 then begin
      v3 := v1 > v0;
      if v3 then begin
          v4 := v0 <= v0;
          if v4 then begin
              Result := 0;
          end else begin
              Result := 3;
          end;
      end else begin
          Result := 2;
      end;
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
