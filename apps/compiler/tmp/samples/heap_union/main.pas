program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  THeap0 = record l0: TUS0; end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function HeapCreate0(a0: TUS0): THeap0;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v4: TUS0;
  v5: THeap0;
  v6: TUS0;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 7;
  v1 := True;
  if v1 then begin
      v4 := US0_Some(v0);
  end else begin
      v4 := US0_None;
  end;
  v5 := HeapCreate0(v4);
  v6 := v5.l0;
  case v6.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v7 := v6.c1_0;
          v8 := v7 = 7;
          if v8 then begin
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
