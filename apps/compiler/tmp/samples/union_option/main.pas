program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
function pick_0(v0: TUS0): LongInt; forward;
function US0_Empty: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Full(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function pick_0(v0: TUS0): LongInt;
var
  v1: LongInt;
begin
  case v0.tag of
      0: begin
          Result := 0;
      end;
      1: begin
          v1 := v0.c1_0;
          Result := v1;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: TUS0;
  v6: TUS0;
  v7: LongInt;
  v8: Boolean;
  v11: Boolean;
  v9: LongInt;
  v10: Boolean;
begin
  v0 := True;
  if v0 then begin
      v3 := US0_Full(7);
  end else begin
      v3 := US0_Empty;
  end;
  if v0 then begin
      v6 := US0_Empty;
  end else begin
      v6 := US0_Full(1);
  end;
  v7 := pick_0(v3);
  v8 := v7 = 7;
  if v8 then begin
      v9 := pick_0(v6);
      v10 := v9 = 0;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
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
