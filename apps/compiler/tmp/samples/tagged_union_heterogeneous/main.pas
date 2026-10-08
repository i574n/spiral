program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: Boolean; end;
function method0(v0: TUS0): LongInt; forward;
function US0_0(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_1(a0: Boolean): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method0(v0: TUS0): LongInt;
var
  v2: Boolean;
  v1: LongInt;
begin
  case v0.tag of
      1: begin
          v2 := v0.c1_0;
          if v2 then begin
              Result := 9;
          end else begin
              Result := 4;
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
  v3: TUS0;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := False;
  if v0 then begin
      v3 := US0_0(7);
  end else begin
      v3 := US0_1(True);
  end;
  v4 := method0(v3);
  v5 := v4 - 9;
  Result := v5;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
