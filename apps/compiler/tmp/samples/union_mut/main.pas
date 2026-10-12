program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: TMut0; end;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: TMut0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: Boolean;
  v4: TUS0;
  v5: TMut0;
  v6: LongInt;
  v7: Boolean;
begin
  v0 := MutCreate0(1);
  v1 := True;
  if v1 then begin
      v4 := US0_Held(v0);
  end else begin
      v4 := US0_Missing;
  end;
  case v4.tag of
      1: begin
          v5 := v4.c1_0;
          v5.l0 := 7;
          v6 := v5.l0;
          v7 := v6 = 7;
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
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
