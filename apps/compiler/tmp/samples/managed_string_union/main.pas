program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: AnsiString; c1_0: LongInt; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_Text(a0: AnsiString): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Number(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function score_0(v0: TUS0): LongInt;
var
  v3: LongInt;
  v1: AnsiString;
  v2: LongInt;
begin
  case v0.tag of
      1: begin
          v3 := v0.c1_0;
          Result := v3;
      end;
      0: begin
          v1 := v0.c0_0;
          v2 := LongInt(Length(v1));
          Result := v2;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v4: TUS0;
  v2: AnsiString;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := False;
  if v0 then begin
      v4 := US0_Number(7);
  end else begin
      v2 := 'qwe';
      v4 := US0_Text(v2);
  end;
  v5 := score_0(v4);
  v6 := score_0(v4);
  v7 := v5 + v6;
  v8 := v7 - 6;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
