program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongWord; c1_1: AnsiString; c1_2: Boolean; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_All(a0: LongWord; a1: AnsiString; a2: Boolean): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: LongWord;
  v2: AnsiString;
  v3: Boolean;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
  v7: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v0.c1_2;
          v4 := v1 = 4000000000;
          if v4 then begin
              v5 := v2 = 'hi';
              v6 := v5;
          end else begin
              v6 := False;
          end;
          v7 := v6 and v3;
          if v7 then begin
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
  v3: Boolean;
  v6: TUS0;
begin
  v0 := 4000000000;
  v1 := 'hi';
  v2 := True;
  v3 := True;
  if v3 then begin
      v6 := US0_All(v0, v1, v2);
  end else begin
      v6 := US0_None;
  end;
  Result := score_0(v6);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
