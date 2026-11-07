program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function pick_0(v0: AnsiString; v1: AnsiString): AnsiString; forward;
function pick_0(v0: AnsiString; v1: AnsiString): AnsiString;
var
  v2: LongInt;
  v3: Boolean;
  v4: AnsiString;
begin
  v2 := LongInt(Length(v0));
  v3 := v2 > 2;
  if v3 then begin
      Result := v1;
  end else begin
      v4 := '';
      Result := v4;
  end;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := 'abc';
  v1 := pick_0(v0, v0);
  v2 := LongInt(Length(v1));
  v3 := v2 - 3;
  Result := v3;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
