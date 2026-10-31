program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongWord; c1_1: AnsiString; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Both(a0: LongWord; a1: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: LongWord;
  v2: AnsiString;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1 = 4000000000;
          if v3 then begin
              v4 := v2 = 'hi';
              v5 := v4;
          end else begin
              v5 := False;
          end;
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
  v0: LongWord;
  v1: AnsiString;
  v2: Boolean;
  v5: TUS0;
begin
  v0 := 4000000000;
  v1 := 'hi';
  v2 := True;
  if v2 then begin
      v5 := US0_Both(v0, v1);
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
