program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
function method0(v0: LongInt): TUS0; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method0(v0: LongInt): TUS0;
var
  v1: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := US0_None;
  end else begin
      Result := US0_Some(v0);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := 7;
  v1 := method0(v0);
  case v1.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v2 := v1.c1_0;
          v3 := v2 = 7;
          if v3 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
