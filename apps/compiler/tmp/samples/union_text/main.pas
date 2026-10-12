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
function US0_Code(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function score_0(v0: TUS0): LongInt;
var
  v4: LongInt;
  v1: AnsiString;
  v2: Boolean;
begin
  case v0.tag of
      1: begin
          v4 := v0.c1_0;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          v2 := v1 = 'hi';
          if v2 then begin
              Result := 2;
          end else begin
              Result := 3;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: AnsiString;
  v4: TUS0;
  v7: TUS0;
  v8: LongInt;
  v9: Boolean;
  v12: Boolean;
  v10: LongInt;
  v11: Boolean;
begin
  v0 := True;
  v1 := 'hi';
  if v0 then begin
      v4 := US0_Text(v1);
  end else begin
      v4 := US0_Code(1);
  end;
  if v0 then begin
      v7 := US0_Code(5);
  end else begin
      v7 := US0_Text(v1);
  end;
  v8 := score_0(v4);
  v9 := v8 = 2;
  if v9 then begin
      v10 := score_0(v7);
      v11 := v10 = 5;
      v12 := v11;
  end else begin
      v12 := False;
  end;
  if v12 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
