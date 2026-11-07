program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c1_1: AnsiString; c1_2: Boolean; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_One(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_All(a0: LongInt; a1: AnsiString; a2: Boolean): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function score_0(v0: TUS0): LongInt;
var
  v2: LongInt;
  v3: AnsiString;
  v4: Boolean;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
  v8: Boolean;
  v1: LongInt;
begin
  case v0.tag of
      1: begin
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := v0.c1_2;
          v5 := v2 = 7;
          if v5 then begin
              v6 := v3 = 'hi';
              v7 := v6;
          end else begin
              v7 := False;
          end;
          v8 := v7 and v4;
          if v8 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := v1;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: LongInt;
  v2: AnsiString;
  v3: Boolean;
  v6: TUS0;
begin
  v0 := True;
  v1 := 7;
  v2 := 'hi';
  v3 := True;
  if v0 then begin
      v6 := US0_All(v1, v2, v3);
  end else begin
      v6 := US0_One(1);
  end;
  Result := score_0(v6);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
