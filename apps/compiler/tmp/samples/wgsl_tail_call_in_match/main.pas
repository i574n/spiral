program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; end;
function layers_0(v0: LongInt): LongInt; forward;
function US0_Done(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_More(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function layers_0(v0: LongInt): LongInt;
var
  v1: Boolean;
  v4: TUS0;
  v8: LongInt;
  v9: LongInt;
  v5: LongInt;
  v6: LongInt;
  tmp6: LongInt;
begin
  while True do begin
      v1 := v0 >= 5;
      if v1 then begin
          v4 := US0_Done(v0);
      end else begin
          v4 := US0_More(v0);
      end;
      case v4.tag of
          0: begin
              v8 := v4.c0_0;
              v9 := v8 * 2;
              Result := v9;
              Exit;
          end;
          1: begin
              v5 := v4.c1_0;
              v6 := v5 + 1;
              tmp6 := v6;
              v0 := tmp6;
              Continue;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 0;
  Result := layers_0(v0);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
