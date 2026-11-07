program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
  TUS0 = record tag: LongInt; c1_0: TArray0; c1_1: Boolean; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: TArray0; a1: Boolean): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: Boolean;
  v3: AnsiString;
  v4: Boolean;
  v5: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1[0];
          v4 := v3 = 'hi';
          v5 := v4 and v2;
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
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: Boolean;
  v5: TUS0;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := 'hi';
  v0[0] := v1;
  v2 := True;
  if v2 then begin
      v5 := US0_Held(v0, v2);
  end else begin
      v5 := US0_None;
  end;
  Result := score_0(v5);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
