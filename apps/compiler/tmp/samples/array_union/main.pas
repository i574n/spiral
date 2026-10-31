program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TArray0 = array of TUS0;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: TUS0;
  v4: TUS0;
  v5: TUS0;
  v6: LongInt;
  v7: TUS0;
  v8: Boolean;
  v10: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v2 := 7;
  v3 := US0_Some(v2);
  v1[0] := v3;
  v4 := US0_None;
  v1[1] := v4;
  v5 := v1[0];
  case v5.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v6 := v5.c1_0;
          v7 := v1[1];
          case v7.tag of
              0: begin
                  v8 := v6 = 7;
                  if v8 then begin
                      Result := 0;
                  end else begin
                      Result := 1;
                  end;
              end;
              1: begin
                  v10 := v7.c1_0;
                  Result := 1;
              end;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
