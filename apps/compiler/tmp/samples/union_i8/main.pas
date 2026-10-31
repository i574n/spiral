program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: ShortInt; end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: ShortInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: ShortInt;
  v1: Boolean;
  v4: TUS0;
  v5: ShortInt;
  v6: Boolean;
begin
  v0 := 100;
  v1 := True;
  if v1 then begin
      v4 := US0_Held(v0);
  end else begin
      v4 := US0_Missing;
  end;
  case v4.tag of
      1: begin
          v5 := v4.c1_0;
          v6 := v5 = 100;
          if v6 then begin
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
