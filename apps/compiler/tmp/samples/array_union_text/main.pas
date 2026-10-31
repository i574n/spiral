program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: AnsiString; c1_1: AnsiString; end;
  TArray0 = array of TUS0;
function score_0(v0: TUS0): LongInt; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Both(a0: AnsiString; a1: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: AnsiString;
  v2: AnsiString;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1 = 'hi';
          if v3 then begin
              v4 := v2 = 'yo';
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
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: AnsiString;
  v3: Boolean;
  v6: TUS0;
  v7: TUS0;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := 'hi';
  v2 := 'yo';
  v3 := True;
  if v3 then begin
      v6 := US0_Both(v1, v2);
  end else begin
      v6 := US0_None;
  end;
  v0[0] := v6;
  v7 := v0[0];
  Result := score_0(v7);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
