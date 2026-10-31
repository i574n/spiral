program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: Boolean;
  v5: TUS0;
  v6: TArray0;
  v7: AnsiString;
  v8: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := 'hi';
  v0[0] := v1;
  v2 := True;
  if v2 then begin
      v5 := US0_Held(v0);
  end else begin
      v5 := US0_Missing;
  end;
  case v5.tag of
      1: begin
          v6 := v5.c1_0;
          v7 := v6[0];
          v8 := v7 = 'hi';
          if v8 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
