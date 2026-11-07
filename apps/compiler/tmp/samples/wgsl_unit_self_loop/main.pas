program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
procedure fill_0(v0: LongInt; v1: TArray0; v2: LongInt); forward;
procedure fill_0(v0: LongInt; v1: TArray0; v2: LongInt);
var
  v3: Boolean;
  v4: LongInt;
begin
  while True do begin
      v3 := v2 < v0;
      if v3 then begin
          v1[v2] := v2;
          v4 := v2 + 1;
          v2 := v4;
          Continue;
      end else begin
          Exit;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 6;
  tmp2 := nil;
  SetLength(tmp2, 6);
  v1 := tmp2;
  v2 := 0;
  fill_0(v0, v1, v2);
  v3 := v1[5];
  v4 := v3 + 2;
  Result := v4;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
