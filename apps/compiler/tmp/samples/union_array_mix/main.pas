program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; c1_1: LongInt; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: TArray0; a1: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1[0];
          v4 := v3 + v2;
          v5 := v4 = 7;
          if v5 then begin
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
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TArray0;
  tmp3: TArray0;
  v3: Boolean;
  v6: TUS0;
begin
  v0 := 3;
  v1 := 4;
  tmp3 := nil;
  SetLength(tmp3, 1);
  v2 := tmp3;
  v2[0] := v0;
  v3 := True;
  if v3 then begin
      v6 := US0_Held(v2, v1);
  end else begin
      v6 := US0_None;
  end;
  Result := score_0(v6);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
