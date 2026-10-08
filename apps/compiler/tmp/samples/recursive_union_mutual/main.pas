program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH1 = class;
  TUH1 = class tag: LongInt; c0_0: TUH0; end;
  TUH0 = class tag: LongInt; c0_0: TUH1; end;
function UH1_0(a0: TUH0): TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH1_1: TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; 
end;
function UH0_0(a0: TUH1): TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH0_1: TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; 
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v5: TUH0;
  v1: TUH0;
  v2: TUH1;
  v6: TUH1;
begin
  v0 := True;
  if v0 then begin
      v1 := UH0_1;
      v2 := UH1_0(v1);
      v5 := UH0_0(v2);
  end else begin
      v5 := UH0_1;
  end;
  case v5.tag of
      0: begin
          v6 := v5.c0_0;
          Result := 0;
      end;
      1: begin
          Result := 0;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
